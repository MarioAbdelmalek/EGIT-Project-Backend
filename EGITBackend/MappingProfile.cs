using AutoMapper;
using BLL.ModelsDto;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EGITBackend
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cluster, ClusterDto>();
            CreateMap<ClusterDto, Cluster>();

            CreateMap<Lun, LunDto>();
            CreateMap<LunDto, Lun>();

            CreateMap<Node, NodeDto>();
            CreateMap<NodeDto, Node>();

            CreateMap<Storage, StorageDto>();
            CreateMap<StorageDto, Storage>();

            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<Client, ClientDto>();
            CreateMap<ClientDto, Client>();

            CreateMap<VM, VMDto>();
            CreateMap<VMDto, VM>();

            CreateMap<Vpn, VpnDto>();
            CreateMap<VpnDto, Vpn>();
        }
    }
}
