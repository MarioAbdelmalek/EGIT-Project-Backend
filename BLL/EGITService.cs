using AutoMapper;
using BLL.ModelsDto;
using DAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class EGITService : IEGITService
    {
        private readonly IMapper mapper;
        IEGITRepository EGITRepository;
        public static DateTime dateTime = DateTime.Now;

        public EGITService (IMapper mapper, IEGITRepository EGITRepository)
        {
            this.mapper = mapper;
            this.EGITRepository = EGITRepository;
        }

        public GenerateErrorDto AddClient(CreateClientDto newClient)
        {
            ClientDto c = new ClientDto
            {
                ClientName = newClient.ClientName,
                ClientSector = newClient.ClientSector,
                ISPID = newClient.ISPID,
                LastUpdateTime = DateTime.Now
            };

            try
            {
                EGITRepository.AddClient(mapper.Map<Client>(c));
                return new GenerateErrorDto { Response = "Client Added Successfully!", IsValid = true };
            }

            catch (Exception)
            {
                return new GenerateErrorDto { Response = "Error Adding The Client!", IsValid = false };
            }
        }

        public GenerateErrorDto AddCluster(CreateClusterDto newCluster)
        {
            ClusterDto c = new ClusterDto { ClusterType = newCluster.ClusterType, ClusterName = newCluster.ClusterName, 
                LastUpdateTime = DateTime.Now};

            try
            {
                EGITRepository.AddCluster(mapper.Map<Cluster>(c));
                return new GenerateErrorDto { Response = "Cluster Added Successfully!", IsValid = true };
            }

            catch (Exception)
            {
                return new GenerateErrorDto { Response = "Error Adding The Cluster!", IsValid = false };
            }

        }

        public GenerateErrorDto CalculateClusterSpace(int ClusterID)
        {
            Cluster returnedCluster = EGITRepository.GetClusterByID(ClusterID);

            if (returnedCluster != null)
            {
                List<Node> returnedClusterNodes = EGITRepository.GetClusterNodes(ClusterID);

                var totalRAM = returnedClusterNodes.Sum(n => n.NodeTotalRAM);
                var remainingRAM = returnedClusterNodes.Sum(n => n.NodeRemainingRAM);
                var totalCPUCores = returnedClusterNodes.Sum(n => n.NodeTotalCPUCores);
                var remainingCPUCores = returnedClusterNodes.Sum(n => n.NodeRemainingCPUCores);
                var totalNodes = returnedClusterNodes.Count();

                returnedCluster.ClusterTotalRAM = totalRAM;
                returnedCluster.ClusterRemainingRAM = remainingRAM;
                returnedCluster.NumberOfNodes = totalNodes;
                returnedCluster.ClusterTotalCPUCores = totalCPUCores;
                returnedCluster.ClusterRemainingCPUCores = remainingCPUCores;

                EGITRepository.UpdateCluster(returnedCluster);
                return new GenerateErrorDto { Response = "Cluster Updated Successfully!", IsValid = true };
            }

            else
            {
                return new GenerateErrorDto { Response = "Cluster Not Found!", IsValid = false };
            }
        }

        public GenerateErrorDto AddNode(CreateNodeDto newNode)
        {
            NodeDto n = new NodeDto

            {
                NodeName = newNode.NodeName,
                NodeTotalCPUCores = newNode.NodeTotalCPUCores,
                NodeTotalRAM = newNode.NodeTotalRAM,
                ClusterID = newNode.ClusterID,
                NodeRemainingCPUCores = newNode.NodeTotalCPUCores,
                NodeRemainingRAM = newNode.NodeTotalRAM,
                LastUpdateTime = DateTime.Now
            };

            ClusterDto nodeCluster = this.GetClusterByID(newNode.ClusterID);

            if(nodeCluster == null)
            {
                return new GenerateErrorDto { Response = "Cluster Not Found, Cannot Add This Node!", IsValid = false };
            }

            try
            {
                EGITRepository.AddNode(mapper.Map<Node>(n));
                this.CalculateClusterSpace(n.ClusterID);
                return new GenerateErrorDto { Response = "Node Added Successfully!", IsValid = true };
            }

            catch (Exception)
            {
                return new GenerateErrorDto { Response = "Error Adding The Node!", IsValid = false };
            }
        }

        public GenerateErrorDto DeleteClient(int ClientID)
        {

            var clientVMsList = EGITRepository.GetClientVMs(ClientID);
            var clientVPNsList = EGITRepository.GetClientVPNs(ClientID);

            if (clientVMsList.Count > 0)
            {
                return new GenerateErrorDto { Response = "Cannot Delete This Client, Please Delete His VMs First!", IsValid = true };
            }

            if (clientVPNsList.Count > 0)
            {
                return new GenerateErrorDto { Response = "Cannot Delete This Client, Please Delete His VPNs First!", IsValid = true };
            }

            try
            {
                EGITRepository.DeleteClient(ClientID);
                return new GenerateErrorDto { Response = "Client Deleted Successfully!", IsValid = true };
            }

            catch (Exception)
            {
                return new GenerateErrorDto { Response = "Error Deleting The Client!", IsValid = false };
            }

        }

        public GenerateErrorDto DeleteCluster(int ClusterID)
        {

            var clusterNodesList = EGITRepository.GetClusterNodes(ClusterID);

            if (clusterNodesList.Count > 0)
            {
                return new GenerateErrorDto { Response = "Cannot Delete This Cluster, Please Delete Its Nodes First!", IsValid = false };
            }

            try
            {
                EGITRepository.DeleteCluster(ClusterID);
                return new GenerateErrorDto { Response = "Cluster Deleted Successfully!", IsValid = true };
            }

            catch (Exception)
            {
                return new GenerateErrorDto { Response = "Error Deleting The Cluster!", IsValid = false };
            }

        }

        public GenerateErrorDto DeleteNode(int NodeID)
        {
            NodeDto nodeToBeDeleted = this.GetNodeByID(NodeID);
            var nodeVMsList = EGITRepository.GetNodeVMs(NodeID);

            if (nodeToBeDeleted == null)
            {
                return new GenerateErrorDto { Response = "Node Not Found, Cannot Delete This Node!", IsValid = false };
            }

            if (nodeVMsList.Count > 0)
            {
                return new GenerateErrorDto { Response = "Cannot Delete This Node, Please Delete Its VMs First!", IsValid = false };
            }

            try
            {
                EGITRepository.DeleteNode(NodeID);
                CalculateClusterSpace(nodeToBeDeleted.ClusterID);
                return new GenerateErrorDto { Response = "Node Deleted Successfully!", IsValid = true };
            }

            catch (Exception)
            {
                return new GenerateErrorDto { Response = "Error Deleting The Node!", IsValid = false };
            }

        }

        public List<ClientDto> GetAllClients()
        {
            var returnedClientsList = EGITRepository.GetAllClients();
            return mapper.Map<List<ClientDto>>(returnedClientsList);
        }

        public List<ClusterDto> GetAllClusters()
        {
            var returnedCLustersList = EGITRepository.GetAllClusters();
            return mapper.Map<List<ClusterDto>>(returnedCLustersList);
        }

        public List<NodeDto> GetAllNodes()
        {
            var returnedNodesList = EGITRepository.GetAllNodes();
            return mapper.Map<List<NodeDto>>(returnedNodesList);
        }

        public ClientDto GetClientByID(int ClientID)
        {
            Client returnedClient = EGITRepository.GetClientByID(ClientID);
            return mapper.Map<ClientDto>(returnedClient);
        }

        public ClusterDto GetClusterByID(int ClusterID)
        {
            Cluster returnedCluster = EGITRepository.GetClusterByID(ClusterID);
            return mapper.Map<ClusterDto>(returnedCluster);
        }

        public NodeDto GetNodeByID(int NodeID)
        {
            Node returnedNode = EGITRepository.GetNodeByID(NodeID);
            return mapper.Map<NodeDto>(returnedNode);
        }

        public GenerateErrorDto UpdateClient(int ClientID, CreateClientDto newClient)
        {
            ClientDto oldClient = GetClientByID(ClientID);

            if (oldClient != null)
            {
                oldClient.ClientName = newClient.ClientName;
                oldClient.ClientSector = newClient.ClientSector;
                oldClient.ISPID = newClient.ISPID;
                oldClient.LastUpdateTime = DateTime.Now;

                EGITRepository.UpdateClient(mapper.Map<Client>(oldClient));
                return new GenerateErrorDto { Response = "Client Updated Successfully!", IsValid = true };
            }

            else
            {
                return new GenerateErrorDto { Response = "Error Updating The Client!", IsValid = false };
            }
        }

        public GenerateErrorDto UpdateCluster(int ClusterID, CreateClusterDto newCluster)
        {
            ClusterDto oldCluster = GetClusterByID(ClusterID);

            if (oldCluster != null)
            {
                oldCluster.ClusterType = newCluster.ClusterType;
                oldCluster.ClusterName = newCluster.ClusterName;
                oldCluster.LastUpdateTime = DateTime.Now;

                EGITRepository.UpdateCluster(mapper.Map<Cluster>(oldCluster));
                return new GenerateErrorDto { Response = "Cluster Updated Successfully!", IsValid = true };
            }

            else
            {
                return new GenerateErrorDto { Response = "Cluster Not Found!", IsValid = false };
            }
        }

        public GenerateErrorDto UpdateNode(int NodeID, CreateNodeDto newNode)
        {
            NodeDto oldNode = this.GetNodeByID(NodeID);

            if (oldNode != null)
            {

                ClusterDto nodeCluster = this.GetClusterByID(newNode.ClusterID);

                if(nodeCluster == null)
                {
                    return new GenerateErrorDto { Response = "Cluster Not Found, Cannot Update This Node!", IsValid = false };
                }

                if(newNode.ClusterID == oldNode.ClusterID)
                {
                    oldNode.NodeName = newNode.NodeName;
                    oldNode.NodeTotalCPUCores = newNode.NodeTotalCPUCores;
                    oldNode.NodeTotalRAM = newNode.NodeTotalRAM;
                    oldNode.ClusterID = newNode.ClusterID;
                    oldNode.LastUpdateTime = DateTime.Now;

                    List<VM> returnedNodeVMs = EGITRepository.GetNodeVMs(NodeID);

                    var totalVMsRAM = returnedNodeVMs.Sum(vm => vm.RAM);
                    var remainingNodeRAM = oldNode.NodeTotalRAM - totalVMsRAM;

                    var totalVMsCPUCores = returnedNodeVMs.Sum(vm => vm.CPUCores);
                    var remainingNodeCPUCores = oldNode.NodeTotalCPUCores - totalVMsCPUCores;

                    oldNode.NodeRemainingCPUCores = remainingNodeCPUCores;
                    oldNode.NodeRemainingRAM = remainingNodeRAM;


                    EGITRepository.UpdateNode(mapper.Map<Node>(oldNode));
                    CalculateClusterSpace(oldNode.ClusterID);
                    return new GenerateErrorDto { Response = "Node Updated Successfully!", IsValid = true };
                }

                else
                {
                    var oldClusterID = oldNode.ClusterID;

                    oldNode.NodeName = newNode.NodeName;
                    oldNode.NodeTotalCPUCores = newNode.NodeTotalCPUCores;
                    oldNode.NodeTotalRAM = newNode.NodeTotalRAM;
                    oldNode.ClusterID = newNode.ClusterID;
                    oldNode.LastUpdateTime = DateTime.Now;

                    List<VM> returnedNodeVMs = EGITRepository.GetNodeVMs(NodeID);

                    var totalVMsRAM = returnedNodeVMs.Sum(vm => vm.RAM);
                    var remainingNodeRAM = oldNode.NodeTotalRAM - totalVMsRAM;

                    var totalVMsCPUCores = returnedNodeVMs.Sum(vm => vm.CPUCores);
                    var remainingNodeCPUCores = oldNode.NodeTotalCPUCores - totalVMsCPUCores;

                    oldNode.NodeRemainingCPUCores = remainingNodeCPUCores;
                    oldNode.NodeRemainingRAM = remainingNodeRAM;

                    EGITRepository.UpdateNode(mapper.Map<Node>(oldNode));
                    CalculateClusterSpace(oldNode.ClusterID);
                    CalculateClusterSpace(oldClusterID);
                    return new GenerateErrorDto { Response = "Node Updated Successfully!", IsValid = true };
                }

            }

            else
            {
                return new GenerateErrorDto { Response = "Node Not Found!", IsValid = false };
            }
        }

        public List<LunDto> GetAllLuns()
        {
            List<Lun> luns= EGITRepository.GetAllLuns();
            return mapper.Map<List<Lun>, List<LunDto>>(luns);
        }
        public GenerateErrorDto AddLun(CreateLunDto lun)
        {

            LunDto newLun = new LunDto
            {
                LunName = lun.LunName,
                LunTotalSpace = lun.LunTotalSpace,
                LunRemainingSpace = lun.LunTotalSpace,
                StorageID = lun.StorageID,
                LastUpdateTime = DateTime.Now

            };
            StorageDto linkedStorage = GetStorage(lun.StorageID);

            if (linkedStorage == null)
            {
                return new GenerateErrorDto { Response = "Storage Not Found, Cannot Create Lun!" };
            }

            if (lun.LunTotalSpace > linkedStorage.StorageRemainingSpace)
            {
                return new GenerateErrorDto { Response = "Lun RAM cannot Exceed Storage RAM!", IsValid = false };
            }
            try
            {
                EGITRepository.AddLun(mapper.Map<Lun>(newLun));
                CalculateStorageSpace(newLun.StorageID);
                return new GenerateErrorDto { Response = "Lun Added Successfully!", IsValid = true };
            }
            catch (Exception)
            {
                return new GenerateErrorDto { Response = "Error Adding The Lun!", IsValid = false };
            }
           
        }
        public LunDto GetLun(int LunID)
        {
            Lun lun = EGITRepository.GetLun(LunID);
            return mapper.Map<LunDto>(lun);
        }
        public GenerateErrorDto DeleteLun(int LunID)
        {

            LunDto lunToBeDeleted = this.GetLun(LunID);
            var lunVMsList = EGITRepository.GetLunVMs(LunID);

            if (lunToBeDeleted == null)
            {
                return new GenerateErrorDto { Response = "Lun Not Found, Cannot Delete This Lun!", IsValid = false };
            }
          

            if (lunVMsList.Count > 0)
            {
                return new GenerateErrorDto { Response = "Cannot Delete This Lun, Please Delete Its VMs First!", IsValid = true };
            }

            try
            {
                EGITRepository.DeleteLun(LunID);
                CalculateStorageSpace(lunToBeDeleted.StorageID);
                return new GenerateErrorDto { Response = "Lun Deleted Successfully!", IsValid = true };
            }

            catch (Exception)
            {
                return new GenerateErrorDto { Response = "Error Deleting The Lun!", IsValid = false };
            }
            
        }
        public GenerateErrorDto UpdateLun(CreateLunDto UpdatedLun,int LunID)
        {

            LunDto LunToBeUpdated = GetLun(LunID);
            StorageDto oldlinkedStorage = GetStorage(LunToBeUpdated.StorageID);
            var remainingStorage = 0;

            if (LunToBeUpdated == null)
            {
                return new GenerateErrorDto { Response = "Lun Not Found, Cannot Update Lun!", IsValid = false };
            }

            if (oldlinkedStorage == null)
            {
                return new GenerateErrorDto { Response = "Storage Not Found, Cannot Update Lun!", IsValid = false };

            }

            remainingStorage =  oldlinkedStorage.StorageRemainingSpace + LunToBeUpdated.LunTotalSpace;

            if (LunToBeUpdated.LunTotalSpace> remainingStorage)
            {
                return new GenerateErrorDto { Response = "Lun Space cannot Exceed Storage Space!", IsValid = false };
            }

            LunToBeUpdated.LunName = UpdatedLun.LunName;
            LunToBeUpdated.LunRemainingSpace = LunToBeUpdated.LunRemainingSpace + (UpdatedLun.LunTotalSpace - LunToBeUpdated.LunTotalSpace);
            LunToBeUpdated.LunTotalSpace = UpdatedLun.LunTotalSpace;
            LunToBeUpdated.StorageID = UpdatedLun.StorageID;
            LunToBeUpdated.LastUpdateTime = DateTime.Now;

            if (LunToBeUpdated.LunTotalSpace > remainingStorage)
            {
                return new GenerateErrorDto { Response = "Lun Space cannot Exceed Storage Space!", IsValid = false };

            }
            try
            {
                EGITRepository.UpdateLun(mapper.Map<Lun>(LunToBeUpdated));
                CalculateStorageSpace(LunToBeUpdated.StorageID);
                CalculateLunSpace(LunToBeUpdated.LunID);
                return new GenerateErrorDto { Response = "Lun Updated Successfully!", IsValid = true };
            
            }
            catch
            {
                return new GenerateErrorDto { Response = "Error Updating The Lun!", IsValid = false };
            }

        }

        public List<StorageDto> GetAllStorages()
        {
            List<Storage> storages = EGITRepository.GetAllStorages();
            return mapper.Map<List<Storage>, List<StorageDto>>(storages);
        }
        public StorageDto GetStorage(int StorageID)
        {
            Storage storage = EGITRepository.GetStorage(StorageID);
            return mapper.Map<StorageDto>(storage);
        }
        public GenerateErrorDto AddStorage(CreateStorageDto storage)

        {
            StorageDto newStorage = new StorageDto
            {
                StorageName = storage.StorageName,
                StorageType = storage.StorageType,
                StorageTotalSpace = storage.StorageTotalSpace,
                StorageRemainingSpace = storage.StorageTotalSpace,
                LastUpdateTime = DateTime.Now

            };

            try
            {
                EGITRepository.AddStorage(mapper.Map<Storage>(newStorage));
                return new GenerateErrorDto { Response = "Storage Added Successfully!", IsValid = true };
            }
            
            catch (Exception)
            {
                return new GenerateErrorDto { Response = "Error Adding The Storage!", IsValid = false };
            }

        }
        public List<LunDto> GetStorageLuns(int StorageID)
        {
            List<Lun> luns = EGITRepository.GetStorageLuns(StorageID);
            return mapper.Map<List<LunDto>>(luns);
        }

        public GenerateErrorDto DeleteStorage(int StorageID)
        {
            if(GetStorage(StorageID)== null)
            {
                return new GenerateErrorDto { Response = "Storage Not Found, Cannot Delete Storage!", IsValid = false };
            }

            var storageLunsList = EGITRepository.GetStorageLuns(StorageID);

            if (storageLunsList.Count > 0)
            {
                return new GenerateErrorDto { Response = "Cannot Delete This Storage, Please Delete Its Luns First!", IsValid = true };
            }

            try
            {
                EGITRepository.DeleteStorage(StorageID);
                return new GenerateErrorDto { Response = "Storage Deleted Successfully!", IsValid = true };
            }

            catch (Exception)
            {
                return new GenerateErrorDto { Response = "Error Deleting The Storage!", IsValid = false };
            } 

        }
        public GenerateErrorDto UpdateStorage(CreateStorageDto UpdatedStorage ,int StorageID)
        {
            StorageDto StorageToBeUpdated = GetStorage(StorageID);

            if (StorageToBeUpdated != null)
            {

                StorageToBeUpdated.StorageName = UpdatedStorage.StorageName;
                StorageToBeUpdated.StorageType = UpdatedStorage.StorageType;
                StorageToBeUpdated.StorageRemainingSpace = StorageToBeUpdated.StorageRemainingSpace
                    + (UpdatedStorage.StorageTotalSpace - StorageToBeUpdated.StorageTotalSpace);
                StorageToBeUpdated.StorageTotalSpace = UpdatedStorage.StorageTotalSpace;
                StorageToBeUpdated.LastUpdateTime = DateTime.Now;




            }
            else
            {
                return new GenerateErrorDto { Response = "Storage Not Found, Cannot Update Storage!", IsValid = false };

            }

            try
            {
                EGITRepository.UpdateStorage(mapper.Map<Storage>(StorageToBeUpdated));
                CalculateStorageSpace(StorageToBeUpdated.StorageID);
                return new GenerateErrorDto { Response = "Storage Updated Successfully!", IsValid = true };
            }
            catch
            {
                return new GenerateErrorDto { Response = "Error Updating The Storage!", IsValid = false };
            }
        }

        public GenerateErrorDto CalculateStorageSpace(int StorageID)
        {
            StorageDto storage = GetStorage(StorageID);
            if (storage == null)
            {
                return new GenerateErrorDto { Response = "Storage Not Found, Cannot Calculate RAM!", IsValid = false };

            }
            List<Lun> luns = EGITRepository.GetStorageLuns(StorageID);

            if (luns == null)
            {
               return new GenerateErrorDto { Response = "Storage Doesn't Contain Luns, Cannot Calculate RAM!", IsValid = false };

            }
            var RemainingSum = storage.StorageTotalSpace - luns.Sum(l => l.LunTotalSpace);
            storage.StorageRemainingSpace = RemainingSum;

            try
            {
                EGITRepository.UpdateStorage(mapper.Map<Storage>(storage));
                return new GenerateErrorDto { Response = " RAM Calculated Successfully!", IsValid = true };
            }
             catch
            {
                return new GenerateErrorDto { Response = "Error Calculating RAM!", IsValid = false };
            }
            
        }

        public GenerateErrorDto CalculateLunSpace(int LunID)
        {
            LunDto lun = GetLun(LunID);
            if (lun == null)
            {
                return new GenerateErrorDto { Response = "Lun Not Found, Cannot Calculate Lun RAM!", IsValid = false };

            }
            List<VM> vms = EGITRepository.GetLunVMs(LunID);
            if (vms == null)
            {
                return new GenerateErrorDto { Response = "Lun Contains no Vms, Cannot Calculate Lun RAM!", IsValid = false };

            }

            var RemainingSum = lun.LunTotalSpace - vms.Sum(l => l.Storage);
            if (RemainingSum > lun.LunTotalSpace)
            {
                return new GenerateErrorDto { Response = "Error Calculating Lun Space!", IsValid = false };

            }
            lun.LunRemainingSpace = RemainingSum;

            try
            {
                EGITRepository.UpdateLun(mapper.Map<Lun>(lun));
                return new GenerateErrorDto { Response = "  Lun Space Calculated Successfully!", IsValid = true };

            }
            catch
            {
                return new GenerateErrorDto { Response = "Error Calculating Lun RAM!", IsValid = false };
            }

        }

        public List<VMDto> GetAllVMs()
        {
            List<VM> VMs = EGITRepository.GetAllVMs();
            return mapper.Map<List<VMDto>>(VMs);
        }
        public VMDto GetVM(int VMID)
        {
            VM VM = EGITRepository.GetVM(VMID);
            return mapper.Map<VMDto>(VM);
        }
        public GenerateErrorDto AddVM(CreateVMDto VM)
        {
            VMDto newVM = new VMDto
            {
                CPUCores = VM.CPUCores,
                RAM = VM.RAM,
                Storage = VM.Storage,
                IP = VM.IP,
                Bandwidth = VM.Bandwidth,
                ClientID = VM.ClientID,
                NodeID = VM.NodeID,
                LunID = VM.LunID,
                LastUpdateTime = DateTime.Now
            };

            NodeDto VMNode = this.GetNodeByID(newVM.NodeID);
            ClientDto VMClient = this.GetClientByID(newVM.ClientID);
            LunDto VMLun = this.GetLun(newVM.LunID);

            if (VMNode == null)
            {
                return new GenerateErrorDto { Response = "Node Not Found, Cannot Add This VM!", IsValid = false };
            }

            if (VMClient == null)
            {
                return new GenerateErrorDto { Response = "Client Not Found, Cannot Add This VM!", IsValid = false };
            }

            if (VMLun == null)
            {
                return new GenerateErrorDto { Response = "Lun Not Found, Cannot Add This VM!", IsValid = false };
            }

            try
            {
                if(newVM.RAM > VMNode.NodeRemainingRAM)
                {
                    return new GenerateErrorDto { Response = "No Enough RAM!", IsValid = false };
                }

                if (newVM.CPUCores > VMNode.NodeRemainingCPUCores)
                {
                    return new GenerateErrorDto { Response = "No Enough CPU Cores!", IsValid = false };
                }

                if (newVM.Storage > VMLun.LunRemainingSpace)
                {
                    return new GenerateErrorDto { Response = "No Enough Storage!", IsValid = false };
                }

                else
                {
                    EGITRepository.AddVM(mapper.Map<VM>(newVM));
                    this.CalculateNodeRemainingSpace(newVM.NodeID);
                    this.CalculateLunSpace(newVM.LunID);
                    this.CalculateClusterSpace(VMNode.ClusterID);
                    return new GenerateErrorDto { Response = "VM Added Successfully!", IsValid = true };
                }
                
            }

            catch (Exception)
            {
                return new GenerateErrorDto { Response = "Error Adding The VM!", IsValid = false };
            }
        }
        public GenerateErrorDto UpdateVM(UpdateVMDto VM, int VMID)
        {
            VMDto oldVM = GetVM(VMID);


            if (oldVM != null)
            {
                LunDto oldVMLun = this.GetLun(oldVM.LunID);

                NodeDto oldVMNode = this.GetNodeByID(oldVM.NodeID);

                LunDto newVMLun = this.GetLun(VM.LunID);

                var remainingRAMs = oldVM.RAM + oldVMNode.NodeRemainingRAM;
                var remainingCPUCors = oldVM.CPUCores + oldVMNode.NodeRemainingCPUCores;
                var remainingStorage = 0;

                if (newVMLun == null)
                {
                    return new GenerateErrorDto { Response = "Lun Not Found!", IsValid = false };

                }
                if (oldVM.LunID == newVMLun.LunID)
                {
                    remainingStorage = oldVM.Storage + oldVMLun.LunRemainingSpace;
                }
                else
                {
                    oldVMLun.LunRemainingSpace += oldVM.Storage;
                    this.EGITRepository.UpdateLun(mapper.Map<Lun>(oldVMLun));
                    remainingStorage = newVMLun.LunRemainingSpace;
                }

                oldVM.CPUCores = VM.CPUCores;
                oldVM.RAM = VM.RAM;
                oldVM.Storage = VM.Storage;
                oldVM.LunID = VM.LunID;
                oldVM.LastUpdateTime = DateTime.Now;

                if (VM.RAM > remainingRAMs)
                {
                    return new GenerateErrorDto { Response = "No Enough RAM!", IsValid = false };
                }

                if (VM.CPUCores > remainingCPUCors)
                {
                    return new GenerateErrorDto { Response = "No Enough CPU Cores!", IsValid = false };
                }

                if (VM.Storage > remainingStorage)
                {
                    return new GenerateErrorDto { Response = "No Enough Storage!", IsValid = false };
                }

                try
                {
                    EGITRepository.UpdateVM(mapper.Map<VM>(oldVM));
                    this.CalculateNodeRemainingSpace(oldVM.NodeID);
                    this.CalculateClusterSpace(oldVMNode.ClusterID);
                    this.CalculateLunSpace(oldVM.LunID);
                    return new GenerateErrorDto { Response = "VM Updated Successfully!", IsValid = true };
                }

                catch (Exception)
                {

                    return new GenerateErrorDto { Response = "Error Updating The VM!", IsValid = false };
                }
            }

            else
            {
                return new GenerateErrorDto { Response = "VM Not Found, Cannot Update This VM!", IsValid = false };
            }
        }

        public GenerateErrorDto DeleteVM(int VMID)
        {
            VMDto VMToBeDeleted = GetVM(VMID);

            if (VMToBeDeleted == null)
            {
                return new GenerateErrorDto { Response = "VM Not Found, Cannot Delete This VM!", IsValid = false };
            }

            NodeDto VMNode = this.GetNodeByID(VMToBeDeleted.NodeID);

            try
            {
                EGITRepository.DeleteVM(VMID);
                this.CalculateNodeRemainingSpace(VMToBeDeleted.NodeID);
                this.CalculateLunSpace(VMToBeDeleted.LunID);
                this.CalculateClusterSpace(VMNode.ClusterID);
                return new GenerateErrorDto { Response = "VM Deleted Successfully!", IsValid = true };
            }

            catch (Exception)
            {
                return new GenerateErrorDto { Response = "Error Deleting The VM!", IsValid = false };
            }
            
        }


        public List<VpnDto> GetAllVpns()
        {
            List<Vpn> Vpns = EGITRepository.GetAllVpns();
            return mapper.Map<List<VpnDto>>(Vpns);
        }
        public VpnDto GetVpn(int VpnID)
        {
            Vpn vpn = EGITRepository.GetVpn(VpnID);
            return mapper.Map<VpnDto>(vpn);
        }
        public GenerateErrorDto AddVpn(CreateVpnDto vpn)

        {
            VpnDto newVpn = new VpnDto
            {
                Username = vpn.Username,
                ClientID = vpn.ClientID,
                LastUpdateTime = DateTime.Now

            };
            
            ClientDto VPNClient = this.GetClientByID(vpn.ClientID);

            if(VPNClient == null)
            {
                return new GenerateErrorDto { Response = "Client Not Found, Cannot Add This VPN!", IsValid = false };
            }

            try
            {
                EGITRepository.AddVpn(mapper.Map<Vpn>(newVpn));
                return new GenerateErrorDto { Response = "VPN Added Successfully!", IsValid = true };
            }

            catch (Exception)
            {
                return new GenerateErrorDto { Response = "Error Adding The VPN!", IsValid = false };
            }
        }
        public GenerateErrorDto DeleteVpn(int VpnID)
        {
            VpnDto VPNToBeDeleted = GetVpn(VpnID);

            if(VPNToBeDeleted == null)
            {
                return new GenerateErrorDto { Response = "VPN Not Found, Cannot Delete This VPN!", IsValid = false };
            }

            try
            {
                EGITRepository.DeleteVpn(VpnID);
                return new GenerateErrorDto { Response = "VPN Deleted Successfully!", IsValid = true };
            }

            catch (Exception)
            {
                return new GenerateErrorDto { Response = "Error Deleting The VPN!", IsValid = false };
            }
            
        }
        public GenerateErrorDto UpdateVpn(CreateVpnDto vpn, int VpnID)
        {
            VpnDto newVpn = GetVpn(VpnID);

            if (newVpn != null)
            {
                newVpn.Username = vpn.Username;
                newVpn.ClientID = vpn.ClientID;
                newVpn.LastUpdateTime = DateTime.Now;

                ClientDto VPNClient = this.GetClientByID(vpn.ClientID);

                if(VPNClient == null)
                {
                    return new GenerateErrorDto { Response = "Client Not Found, Cannot Update This VPN!", IsValid = false };
                }

                EGITRepository.UpdateVpn(mapper.Map<Vpn>(newVpn));
                return new GenerateErrorDto { Response = "VPN Updated Successfully!", IsValid = true };
            }

            else
            {
                return new GenerateErrorDto { Response = "VPN Not Found!", IsValid = false };
            }
        }

        public GenerateErrorDto CalculateNodeRemainingSpace(int NodeID)
        {
            Node returnedNode = EGITRepository.GetNodeByID(NodeID);

            if (returnedNode != null)
            {
                List<VM> returnedNodeVMs = EGITRepository.GetNodeVMs(NodeID);

                var totalVMsRAM = returnedNodeVMs.Sum(vm => vm.RAM);
                var remainingNodeRAM = returnedNode.NodeTotalRAM - totalVMsRAM;

                var totalVMsCPUCores = returnedNodeVMs.Sum(vm => vm.CPUCores);
                var remainingNodeCPUCores = returnedNode.NodeTotalCPUCores - totalVMsCPUCores;

                returnedNode.NodeRemainingCPUCores = remainingNodeCPUCores;
                returnedNode.NodeRemainingRAM = remainingNodeRAM;


                EGITRepository.UpdateNode(returnedNode);
                return new GenerateErrorDto { Response = "Node Updated Successfully!", IsValid = true };
            }

            else
            {
                return new GenerateErrorDto { Response = "Node Not Found!", IsValid = false };
            }
        }

        public List<NodeDto> GetClusterNodes(int ClusterID)
        {
            ClusterDto returnedCluster = this.GetClusterByID(ClusterID);

            if(returnedCluster != null)
            {
                var returnedClusterNodesList = EGITRepository.GetClusterNodes(ClusterID);
                return mapper.Map<List<NodeDto>>(returnedClusterNodesList);
            }

            else
            {
                return null;
            }
        }

        public List<ClusterDto> GetClustersByType(string ClusterType)
        {
            var returnedClustersList = EGITRepository.GetClustersByType(ClusterType);
            return mapper.Map<List<ClusterDto>>(returnedClustersList);
        }

        public List<VMDto> GetNodeVMs(int NodeID)
        {
            NodeDto returnedNode = this.GetNodeByID(NodeID);

            if (returnedNode != null)
            {
                var returnedNodeVMsList = EGITRepository.GetNodeVMs(NodeID);
                return mapper.Map<List<VMDto>>(returnedNodeVMsList);
            }

            else
            {
                return null;
            }
        }

        public List<ClusterDto> GetUpdatedClusters()
        {
            var mappedUpdatedClusterList = EGITRepository.GetUpdatedClusters(dateTime);

            if (mappedUpdatedClusterList != null)
            {
                foreach (Cluster c in mappedUpdatedClusterList)
                {
                    if (c.LastUpdateTime > dateTime)
                    {
                        dateTime = c.LastUpdateTime;
                    }
                }
            }
            return mapper.Map<List<ClusterDto>>(mappedUpdatedClusterList);
        }

        public List<NodeDto> GetUpdatedNodes()
        {
            var mappedUpdatedNodeList = EGITRepository.GetUpdatedNodes(dateTime);

            if (mappedUpdatedNodeList != null)
            {
                foreach (Node n in mappedUpdatedNodeList)
                {
                    if (n.LastUpdateTime > dateTime)
                    {
                        dateTime = n.LastUpdateTime;
                    }
                }
            }
            return mapper.Map<List<NodeDto>>(mappedUpdatedNodeList);
        }

        public List<VMDto> GetUpdatedVMs()
        {
            var mappedUpdatedVMList = EGITRepository.GetUpdatedVMs(dateTime);

            if (mappedUpdatedVMList != null)
            {
                foreach (VM vm in mappedUpdatedVMList)
                {
                    if (vm.LastUpdateTime > dateTime)
                    {
                        dateTime = vm.LastUpdateTime;
                    }
                }
            }
            return mapper.Map<List<VMDto>>(mappedUpdatedVMList);
        }

        public List<StorageDto> GetUpdatedStorages()
        {
            var mappedUpdatedStorageList = EGITRepository.GetUpdatedStorages(dateTime);

            if (mappedUpdatedStorageList != null)
            {
                foreach (Storage st in mappedUpdatedStorageList)
                {
                    if (st.LastUpdateTime > dateTime)
                    {
                        dateTime = st.LastUpdateTime;
                    }
                }
            }
            return mapper.Map<List<StorageDto>>(mappedUpdatedStorageList);
        }

        public List<LunDto> GetUpdatedLuns()
        {
            var mappedUpdatedLunList = EGITRepository.GetUpdatedLuns(dateTime);

            if (mappedUpdatedLunList != null)
            {
                foreach (Lun l in mappedUpdatedLunList)
                {
                    if (l.LastUpdateTime > dateTime)
                    {
                        dateTime = l.LastUpdateTime;
                    }
                }
            }
            return mapper.Map<List<LunDto>>(mappedUpdatedLunList);
        }

        public List<VpnDto> GetUpdatedVPNs()
        {
            var mappedUpdatedVPNList = EGITRepository.GetUpdatedVPNs(dateTime);

            if (mappedUpdatedVPNList != null)
            {
                foreach (Vpn vpn in mappedUpdatedVPNList)
                {
                    if (vpn.LastUpdateTime > dateTime)
                    {
                        dateTime = vpn.LastUpdateTime;
                    }
                }
            }
            return mapper.Map<List<VpnDto>>(mappedUpdatedVPNList);
        }

        public List<ClientDto> GetUpdatedClients()
        {
            var mappedClientList = EGITRepository.GetUpdatedClients(dateTime);

            if (mappedClientList != null)
            {
                foreach (Client c in mappedClientList)
                {
                    if (c.LastUpdateTime > dateTime)
                    {
                        dateTime = c.LastUpdateTime;
                    }
                }
            }
            return mapper.Map<List<ClientDto>>(mappedClientList);
        }
    }
}
