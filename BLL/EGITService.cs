using AutoMapper;
using BLL.ModelsDto;
using DAL;
using DAL.Models;
using System;
using System.Collections.Generic;

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

        public void AddClient(CreateClientDto newClient)
        {
            ClientDto c = new ClientDto
            {
                ClientName = newClient.ClientName,
                ClientSector = newClient.ClientSector,
                ISPID = newClient.ISPID
            };
            EGITRepository.AddClient(mapper.Map<Client>(c));
        }

        public void AddCluster(CreateClusterDto newCluster)
        {
            ClusterDto c = new ClusterDto { ClusterType = newCluster.ClusterType, NumberOfNodes = newCluster.NumberOfNodes,
                ClusterRemainingCPUCores = newCluster.ClusterRemainingCPUCores, 
                ClusterRemainingRAM = newCluster.ClusterRemainingRAM, ClusterTotalCPUCores = newCluster.ClusterTotalCPUCores, ClusterTotalRAM = newCluster.ClusterTotalRAM};

            EGITRepository.AddCluster(mapper.Map<Cluster>(c));
        }

        public void AddNode(CreateNodeDto newNode)
        {
            NodeDto n = new NodeDto
            {
                NodeTotalCPUCores = newNode.NodeTotalCPUCores,
                NodeRemainingCPUCores = newNode.NodeRemainingCPUCores,
                NodeTotalRAM = newNode.NodeTotalRAM,
                NodeRemainingRAM = newNode.NodeRemainingRAM,
                ClusterID = newNode.ClusterID
            };
            EGITRepository.AddNode(mapper.Map<Node>(n));
        }

        public void DeleteClient(int ClientID)
        {
            EGITRepository.DeleteClient(ClientID);
        }

        public void DeleteCluster(int ClusterID)
        {
            EGITRepository.DeleteCluster(ClusterID);
        }

        public void DeleteNode(int NodeID)
        {
            EGITRepository.DeleteNode(NodeID);
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

        public void UpdateClient(int ClientID, CreateClientDto newClient)
        {
            ClientDto oldClient = GetClientByID(ClientID);
            if (oldClient != null)
            {
                oldClient.ClientName = newClient.ClientName;
                oldClient.ClientSector = newClient.ClientSector;
                oldClient.ISPID = newClient.ISPID;

                EGITRepository.UpdateClient(mapper.Map<Client>(oldClient));
            }
        }

        public void UpdateCluster(int ClusterID, CreateClusterDto newCluster)
        {
            ClusterDto oldCluster = GetClusterByID(ClusterID);
            if (oldCluster != null)
            {
                oldCluster.ClusterType = newCluster.ClusterType;
                oldCluster.NumberOfNodes = newCluster.NumberOfNodes;
                oldCluster.ClusterRemainingCPUCores = newCluster.ClusterRemainingCPUCores;
                oldCluster.ClusterRemainingRAM = newCluster.ClusterRemainingRAM;
                oldCluster.ClusterTotalCPUCores = newCluster.ClusterTotalCPUCores;
                oldCluster.ClusterTotalRAM = newCluster.ClusterTotalRAM;

                EGITRepository.UpdateCluster(mapper.Map<Cluster>(oldCluster));
            }
        }

        public void UpdateNode(int NodeID, CreateNodeDto newNode)
        {
            NodeDto oldNode = GetNodeByID(NodeID);
            if (oldNode != null)
            {
                oldNode.NodeTotalCPUCores = newNode.NodeTotalCPUCores;
                oldNode.NodeRemainingCPUCores = newNode.NodeRemainingCPUCores;
                oldNode.NodeTotalRAM = newNode.NodeTotalRAM;
                oldNode.NodeRemainingRAM = newNode.NodeRemainingRAM;
                oldNode.ClusterID = newNode.ClusterID;

                EGITRepository.UpdateNode(mapper.Map<Node>(oldNode));
            }
        }

        //Lun functions
        public List<LunDto> GetAllLuns()
        {
            List<Lun> luns= EGITRepository.GetAllLuns();
            return mapper.Map<List<Lun>, List<LunDto>>(luns);
        }
        public void AddLun(LunDto lun)
        {
            EGITRepository.AddLun(mapper.Map<Lun>(lun));
        }
        public LunDto GetLun(int LunID)
        {
            Lun lun = EGITRepository.GetLun(LunID);
            return mapper.Map<LunDto>(lun);
        }
        public void DeleteLun(int LunID)
        {
            EGITRepository.DeleteLun(LunID);
        }
        public void UpdateLun(LunDto lun,int LunID)
        {

            LunDto newlun = GetLun(LunID);

            if (newlun != null)
            {
                newlun.LunName = lun.LunName;
                newlun.LunRemainingRAM = lun.LunRemainingRAM;
                newlun.LunTotalRAM = lun.LunTotalRAM;
                newlun.StorageID = lun.StorageID;
            }

            EGITRepository.UpdateLun(mapper.Map<Lun>(newlun));
        }
        public int getTSpaceByStockId(int StockID)
        {
            return EGITRepository.getTSpaceByStockId(StockID);
        }

        //Storage functions

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
        public void AddStorage(StorageDto storage)

        {
            StorageDto newStorage = new StorageDto
            {
                StorageName = storage.StorageName,
                StorageType = storage.StorageType,
                StorageRemainingRAM = storage.StorageRemainingRAM,
                StorageTotalRAM = storage.StorageTotalRAM

            };
            EGITRepository.AddStorage(mapper.Map<Storage>(storage));

        }
        public void DeleteStorage(int StorageID)
        {
            EGITRepository.DeleteStorage(StorageID);

        }
        public void UpdateStorage(StorageDto storage ,int StorageID)
        {
            StorageDto newStorage = GetStorage(StorageID);
            if (newStorage != null)
            {
                newStorage.StorageName = storage.StorageName;
                newStorage.StorageType = storage.StorageType;
                newStorage.StorageRemainingRAM = storage.StorageRemainingRAM;
                newStorage.StorageTotalRAM = storage.StorageTotalRAM;
            }
            EGITRepository.UpdateStorage(mapper.Map<Storage>(newStorage));
        }
    }
}
