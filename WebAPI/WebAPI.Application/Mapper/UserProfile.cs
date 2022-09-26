using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Contract.Requests;
using WebAPI.Contract.Response;
using WebAPI.Persistence.Domains;

namespace WebAPI.Application.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            #region CreateUserRequest => User
            CreateMap<CreateUserRequest, User>()
            .ForPath(
                    dest => dest.UserDetail.FirstName,
                    opt => opt.MapFrom(s => s.FirstName)
                )
            .ForPath(
                    dest => dest.UserDetail.LastName,
                    opt => opt.MapFrom(s => s.LastName)
                )
            .ForPath(
                    dest => dest.UserDetail.PhoneNumber,
                    opt => opt.MapFrom(s => s.PhoneNumber)
                )
            .ForPath(
                    dest => dest.UserDetail.Address,
                    opt => opt.MapFrom(s => s.Address)
                );
            #endregion

            #region EditUserRequest => User
            CreateMap<EditUserRequest, User>()
            .ForPath(
                    dest => dest.UserDetail.FirstName,
                    opt => opt.MapFrom(s => s.FirstName)
                )
            .ForPath(
                    dest => dest.UserDetail.LastName,
                    opt => opt.MapFrom(s => s.LastName)
                )
            .ForPath(
                    dest => dest.UserDetail.PhoneNumber,
                    opt => opt.MapFrom(s => s.PhoneNumber)
                )
            .ForPath(
                    dest => dest.UserDetail.Address,
                    opt => opt.MapFrom(s => s.Address)
                );
            #endregion

            #region User => EditUserRequest
            CreateMap<User, EditUserRequest>()
                .ForPath(
                    dest => dest.FirstName,
                    opt => opt.MapFrom(s => s.UserDetail.FirstName)
                )
                .ForPath(
                    dest => dest.LastName,
                    opt => opt.MapFrom(s => s.UserDetail.LastName)
                )
                .ForPath(
                    dest => dest.PhoneNumber,
                    opt => opt.MapFrom(s => s.UserDetail.PhoneNumber)
                )
                .ForPath(
                    dest => dest.Address,
                    opt => opt.MapFrom(s => s.UserDetail.Address)
                );
            #endregion

            #region User => GetUserResponse
            CreateMap<User, GetUserResponse>()
                .ForPath(
                    dest => dest.FirstName,
                    opt => opt.MapFrom(s => s.UserDetail.FirstName)
                )
                .ForPath(
                    dest => dest.LastName,
                    opt => opt.MapFrom(s => s.UserDetail.LastName)
                )
                .ForPath(
                    dest => dest.PhoneNumber,
                    opt => opt.MapFrom(s => s.UserDetail.PhoneNumber)
                )
                .ForPath(
                    dest => dest.Address,
                    opt => opt.MapFrom(s => s.UserDetail.Address)
                );
            #endregion
        }
    }
}
