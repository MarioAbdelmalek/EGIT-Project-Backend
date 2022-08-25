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
                ISPID = newClient.ISPID
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
            ClusterDto c = new ClusterDto { ClusterType = newCluster.ClusterType, NumberOfNodes = newCluster.NumberOfNodes};

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

        public GenerateErrorDto AddNode(CreateNodeDto newNode)
        {
            NodeDto n = new NodeDto

            {
                NodeTotalCPUCores = newNode.NodeTotalCPUCores,
                NodeTotalRAM = newNode.NodeTotalRAM,
                ClusterID = newNode.ClusterID,
                NodeRemainingCPUCores = newNode.NodeTotalCPUCores,
                NodeRemainingRAM = newNode.NodeTotalRAM
            };

            ClusterDto nodeCluster = this.GetClusterByID(newNode.ClusterID);

            if(nodeCluster == null)
            {
                return new GenerateErrorDto { Response = "Cluster Not Found, Cannot Add This Node!", IsValid = false };
            }

            try
            {
                EGITRepository.AddNode(mapper.Map<Node>(n));
                CalculateClusterSpace(n.ClusterID);
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
                return new GenerateErrorDto { Response = "Cannot Delete This Cluster, Please Delete Its Nodes First!", IsValid = true };
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
                return new GenerateErrorDto { Response = "Cannot Delete This Node, Please Delete Its VMs First!", IsValid = true };
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
                oldCluster.NumberOfNodes = newCluster.NumberOfNodes;

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
                    oldNode.NodeTotalCPUCores = newNode.NodeTotalCPUCores;
                    oldNode.NodeTotalRAM = newNode.NodeTotalRAM;
                    oldNode.ClusterID = newNode.ClusterID;

                    EGITRepository.UpdateNode(mapper.Map<Node>(oldNode));
                    CalculateClusterSpace(oldNode.ClusterID);
                    return new GenerateErrorDto { Response = "Node Updated Successfully!", IsValid = true };
                }

                else
                {
                    var oldClusterID = oldNode.ClusterID;

                    oldNode.NodeTotalCPUCores = newNode.NodeTotalCPUCores;
                    oldNode.NodeTotalRAM = newNode.NodeTotalRAM;
                    oldNode.ClusterID = newNode.ClusterID;

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
            StorageDto linkedStorage = GetStorage(lun.StorageID);

            LunDto newLun = new LunDto
            {
                LunName = lun.LunName,
                LunTotalRAM = lun.LunTotalRAM,
                StorageID = lun.StorageID,
                LunRemainingRAM=lun.LunTotalRAM,
            };

            try
            {
                if (lun.LunTotalRAM > linkedStorage.StorageRemainingRAM)
                {
                    return new GenerateErrorDto { Response = "Lun RAM cannot Exceed Storage RAM!", IsValid = false };
                }
                else
                {
                    EGITRepository.AddLun(mapper.Map<Lun>(newLun));
                    CalculateStorageRAM(newLun.StorageID);
                    return new GenerateErrorDto { Response = "Lun Added Successfully!", IsValid = true };
                }

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

            LunDto LunToBeDeleted = GetLun(LunID);
            try
            {
                EGITRepository.DeleteLun(LunID);
                CalculateStorageRAM(LunToBeDeleted.StorageID);
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
            StorageDto linkedStorage = GetStorage(LunToBeUpdated.StorageID);
            var StorageRemainingRAM = -1;



            if (LunToBeUpdated != null && linkedStorage!=null)
            {
                StorageRemainingRAM = linkedStorage.StorageRemainingRAM + LunToBeUpdated.LunTotalRAM;
                var newLunRemaining = (UpdatedLun.LunTotalRAM - LunToBeUpdated.LunTotalRAM) + LunToBeUpdated.LunRemainingRAM;

                LunToBeUpdated.LunName = UpdatedLun.LunName;
                LunToBeUpdated.LunTotalRAM = UpdatedLun.LunTotalRAM;
                LunToBeUpdated.StorageID = UpdatedLun.StorageID;
                LunToBeUpdated.LunRemainingRAM = newLunRemaining;
            }  

            try
            {
                if (LunToBeUpdated.LunTotalRAM> StorageRemainingRAM)
                {
                    return new GenerateErrorDto { Response = "Lun RAM cannot Exceed Storage RAM!", IsValid = false };
                }

                else
                {
                    EGITRepository.UpdateLun(mapper.Map<Lun>(LunToBeUpdated));
                    CalculateStorageRAM(LunToBeUpdated.StorageID);
                    return new GenerateErrorDto { Response = "Lun Updated Successfully!", IsValid = true };
                }
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
                StorageTotalRAM = storage.StorageTotalRAM,
                StorageRemainingRAM = storage.StorageTotalRAM
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
        public GenerateErrorDto DeleteStorage(int StorageID)
        {

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
                var newRemaining = (UpdatedStorage.StorageTotalRAM - StorageToBeUpdated.StorageTotalRAM) + StorageToBeUpdated.StorageRemainingRAM;

                StorageToBeUpdated.StorageName = UpdatedStorage.StorageName;
                StorageToBeUpdated.StorageType = UpdatedStorage.StorageType;
                StorageToBeUpdated.StorageTotalRAM = UpdatedStorage.StorageTotalRAM;
                StorageToBeUpdated.StorageRemainingRAM = newRemaining;

                EGITRepository.UpdateStorage(mapper.Map<Storage>(StorageToBeUpdated));
                return new GenerateErrorDto { Response = "Storage Updated Successfully!", IsValid = true };
            }

            else
            {
                return new GenerateErrorDto { Response = "Error Updating The Storage!", IsValid = false };
            }
        }

        public GenerateErrorDto CalculateClusterSpace(int ClusterID)
        {
            Cluster returnedCluster = EGITRepository.GetClusterByID(ClusterID);

            if(returnedCluster != null)
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
        public GenerateErrorDto CalculateStorageRAM(int StorageID)
        {
            StorageDto storage = GetStorage(StorageID);
            if (storage != null)
            {
                List<Lun> luns = EGITRepository.GetStorageLuns(StorageID);
                var RemainingSum  = storage.StorageTotalRAM - luns.Sum(l => l.LunTotalRAM);
                storage.StorageRemainingRAM = RemainingSum;

                EGITRepository.UpdateStorage(mapper.Map<Storage>(storage));
                return new GenerateErrorDto { Response = " RAM Calculated Successfully!", IsValid = true };
            }

        else
            {
                return new GenerateErrorDto { Response = "Error Calculating RAM!", IsValid = false };
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
                CpuCores = VM.CpuCores,
                RAM = VM.RAM,
                IP = VM.IP,
                Bandwidth = VM.Bandwidth,
                ClientID = VM.ClientID,
                NodeID = VM.NodeID,
                LunID = VM.LunID
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
                if(newVM.RAM > VMNode.NodeRemainingRAM || newVM.CpuCores > VMNode.NodeRemainingCPUCores)
                {
                    return new GenerateErrorDto { Response = "No Enough RAM or CPU Cores!", IsValid = false };
                }

                else
                {
                    EGITRepository.AddVM(mapper.Map<VM>(newVM));
                    this.CalculateNodeRemainingSpace(newVM.NodeID);
                    this.CalculateClusterSpace(VMNode.ClusterID);
                    return new GenerateErrorDto { Response = "VM Added Successfully!", IsValid = true };
                }
                
            }

            catch (Exception)
            {
                return new GenerateErrorDto { Response = "Error Adding The VM!", IsValid = false };
            }
        }
        public GenerateErrorDto UpdateVM(CreateVMDto VM, int VMID)
        {
            VMDto newVM = GetVM(VMID);
            NodeDto newVMNode = this.GetNodeByID(newVM.NodeID);

            NodeDto VMNode = this.GetNodeByID(VM.NodeID);

            if (VMNode == null)
            {
                return new GenerateErrorDto { Response = "Node Not Found, Cannot Update This VM!", IsValid = false };
            }

            var remainingRAMs = -1;
            var remainingCPUCors = -1;

            if (newVM != null)
            {
                var oldNodeID = newVM.NodeID;

                if (newVM.NodeID == VM.NodeID)
                {
                    remainingRAMs = newVM.RAM + VMNode.NodeRemainingRAM;
                    remainingCPUCors = newVM.CpuCores + VMNode.NodeRemainingCPUCores;

                    newVM.CpuCores = VM.CpuCores;
                    newVM.RAM = VM.RAM;
                    newVM.IP = VM.IP;
                    newVM.Bandwidth = VM.Bandwidth;
                    newVM.ClientID = VM.ClientID;
                    newVM.NodeID = VM.NodeID;
                    newVM.LunID = VM.LunID;

                    if (VM.RAM > remainingRAMs || VM.CpuCores > remainingCPUCors)
                    {
                        return new GenerateErrorDto { Response = "No Enough RAM or CPU Cores!", IsValid = false };
                    }

                    try
                    {
                        EGITRepository.UpdateVM(mapper.Map<VM>(newVM));
                        this.CalculateNodeRemainingSpace(newVM.NodeID);
                        this.CalculateClusterSpace(VMNode.ClusterID);
                        return new GenerateErrorDto { Response = "VM Updated Successfully!", IsValid = true };
                    }

                    catch (Exception)
                    {
                        return new GenerateErrorDto { Response = "Error Updating The VM!", IsValid = false };
                    }

                }

                else
                {

                    if (VM.RAM > VMNode.NodeRemainingRAM || VM.CpuCores > VMNode.NodeRemainingCPUCores)
                    {
                        return new GenerateErrorDto { Response = "No Enough RAM or CPU Cores!", IsValid = false };
                    }

                    else
                    {
                        newVM.CpuCores = VM.CpuCores;
                        newVM.RAM = VM.RAM;
                        newVM.IP = VM.IP;
                        newVM.Bandwidth = VM.Bandwidth;
                        newVM.ClientID = VM.ClientID;
                        newVM.NodeID = VM.NodeID;
                        newVM.LunID = VM.LunID;
                    }

                    try
                    {
                        EGITRepository.UpdateVM(mapper.Map<VM>(newVM));
                        this.CalculateNodeRemainingSpace(newVM.NodeID);
                        this.CalculateNodeRemainingSpace(oldNodeID);

                        if(newVMNode.ClusterID == VMNode.ClusterID)
                        {
                            this.CalculateClusterSpace(newVMNode.ClusterID);
                        }
                        else
                        {
                            this.CalculateClusterSpace(newVMNode.ClusterID);
                            this.CalculateClusterSpace(VMNode.ClusterID);
                        }

                        return new GenerateErrorDto { Response = "VM Updated Successfully!", IsValid = true };
                    }
                    catch (Exception)
                    {
                        return new GenerateErrorDto { Response = "Error Updating The VM!", IsValid = false };
                    }
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
            NodeDto VMNode = this.GetNodeByID(VMToBeDeleted.NodeID);

            if (VMToBeDeleted == null)
            {
                return new GenerateErrorDto { Response = "VM Not Found, Cannot Delete This VM!", IsValid = false };
            }

            try
            {
                EGITRepository.DeleteVM(VMID);
                this.CalculateNodeRemainingSpace(VMToBeDeleted.NodeID);
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
                ClientID = vpn.ClientID
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
                //ClusterDto nodeCluster = this.GetClusterByID(returnedNode.ClusterID);
                List<VM> returnedNodeVMs = EGITRepository.GetNodeVMs(NodeID);

                var totalVMsRAM = returnedNodeVMs.Sum(vm => vm.RAM);
                var remainingNodeRAM = returnedNode.NodeTotalRAM - totalVMsRAM;

                var totalVMsCPUCores = returnedNodeVMs.Sum(vm => vm.CpuCores);
                var remainingNodeCPUCores = returnedNode.NodeTotalCPUCores - totalVMsCPUCores;

                returnedNode.NodeRemainingCPUCores = remainingNodeCPUCores;
                returnedNode.NodeRemainingRAM = remainingNodeRAM;


                EGITRepository.UpdateNode(returnedNode);
                //this.CalculateClusterSpace(nodeCluster.ClusterID);
                return new GenerateErrorDto { Response = "Node Updated Successfully!", IsValid = true };
            }

            else
            {
                return new GenerateErrorDto { Response = "Node Not Found!", IsValid = false };
            }
        }
    }
}
