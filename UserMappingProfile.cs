using AutoMapper;
using System;
using smert.Models;
using smert.Models.DTO;

namespace smert.Configuration {
    public class UserMappingProfile : Profile {
        public UserMappingProfile() {
            var configuration = new MapperConfiguration(cfg => {
                cfg.CreateMap<User, UserDTO>()
                .ForMember(d => d.user_id, opt => opt.MapFrom(src => src.userId))
                .ForMember(d => d.user_name, opt => opt.MapFrom(src => src.userName))
                .ForMember(d => d.first_name, opt => opt.MapFrom(src => src.firstName))
                .ForMember(d => d.middle_name, opt => opt.MapFrom(src => src.middleName))
                .ForMember(d => d.last_name, opt => opt.MapFrom(src => src.lastName))
                .ForMember(d => d.referall_user_id, opt => opt.MapFrom(src => src.referralUserId))
                .ForMember(d => d.create_time_stamp, opt => opt.MapFrom(src => src.createTimestamp))
                .ForMember(d => d.suppress_time_stamp, opt => opt.MapFrom(src => src.suppressTimestamp))
                .ForMember(d => d.modify_time_stamp, opt => opt.MapFrom(src => src.modifyTimestamp))
                .ForMember(d => d.modify_user_id, opt => opt.MapFrom(src => src.modifyUserId))
                .ReverseMap();
                });
        }

        public static MapperConfiguration CreateConfiguration() {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(cfg.GetType().Assembly);
            });
            return config;
        }
        
    }
}