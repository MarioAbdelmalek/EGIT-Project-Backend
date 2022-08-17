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
                Bandwidth = newClient.Bandwidth,
                ClientSector = newClient.ClientSector,
                CurrentVMs = newClient.CurrentVMs,
                ISPID = newClient.ISPID,
                PublicIps = newClient.PublicIps,
                TotalVMs = newClient.TotalVMs,
                VPNClients = newClient.VPNClients
            };
            EGITRepository.AddClient(mapper.Map<Client>(c));
        }

        public void AddCluster(CreateClusterDto newCluster)
        {
            ClusterDto c = new ClusterDto { ClusterName = newCluster.ClusterName, ClusterType = newCluster.ClusterType };
            EGITRepository.AddCluster(mapper.Map<Cluster>(c));
        }

        public void AddNode(CreateNodeDto newNode)
        {
            NodeDto n = new NodeDto
            { 
                NodeName = newNode.NodeName,
                NodeType = newNode.NodeType,
                TotalCPUCores = newNode.TotalCPUCores,
                RemainingCPUCores = newNode.RemainingCPUCores,
                TotalRAM = newNode.TotalRAM,
                RemainingRAM = newNode.RemainingRAM,
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
                oldClient.TotalVMs = newClient.TotalVMs;
                oldClient.Bandwidth = newClient.Bandwidth;
                oldClient.ClientName = newClient.ClientName;
                oldClient.ClientSector = newClient.ClientSector;
                oldClient.CurrentVMs = newClient.CurrentVMs;
                oldClient.ISPID = newClient.ISPID;
                oldClient.PublicIps = newClient.PublicIps;
                oldClient.VPNClients = newClient.VPNClients;
                EGITRepository.UpdateClient(mapper.Map<Client>(oldClient));
            }
        }

        public void UpdateCluster(int ClusterID, CreateClusterDto newCluster)
        {
            ClusterDto oldCluster = GetClusterByID(ClusterID);
            if (oldCluster != null)
            {
                oldCluster.ClusterName = newCluster.ClusterName;
                oldCluster.ClusterType = newCluster.ClusterType;
                EGITRepository.UpdateCluster(mapper.Map<Cluster>(oldCluster));
            }
        }

        public void UpdateNode(int NodeID, CreateNodeDto newNode)
        {
            NodeDto oldNode = GetNodeByID(NodeID);
            if (oldNode != null)
            {
                oldNode.NodeName = newNode.NodeName;
                oldNode.NodeType = newNode.NodeType;
                oldNode.TotalCPUCores = newNode.TotalCPUCores;
                oldNode.RemainingCPUCores = newNode.RemainingCPUCores;
                oldNode.TotalRAM = newNode.TotalRAM;
                oldNode.RemainingRAM = newNode.RemainingRAM;
                oldNode.ClusterID = newNode.ClusterID;
                EGITRepository.UpdateNode(mapper.Map<Node>(oldNode));
            }
        }
    }
}
