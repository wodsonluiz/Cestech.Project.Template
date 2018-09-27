using Cestech.Application.Dto;
using Cestech.Application.Interfaces;
using Cestech.Domain.Entities;
using Cestech.Domain.Interfaces;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cestech.Application.Services
{
    public class ApplicationServiceUsuario : IApplicationServiceUsuario
    {
        private readonly IServiceUsuario _service;

        public ApplicationServiceUsuario(IServiceUsuario service)
        {
            _service = service;
        }

        public ServiceResponse<bool> Delete(int id)
        {
            var result = new ServiceResponse<bool>();

            try
            {
                result.Result = result.Object = _service.Delete(id);

                if (!result.Result)
                {
                    ((Notifiable)_service).Notifications
                        .ToList()
                        .ForEach(x => result.Messages.Add(x.Message));
                }
            }
            catch (Exception ex)
            {
                result.Messages.Add("Problema ao Deletar o Usuário" + ex.Message);
            }
            return result;
        }

        public ServiceResponse<bool> Insert(UsuarioDto usuario)
        {
            var result = new ServiceResponse<bool>();

            try
            {
                var query = new Usuario(usuario.Nome, usuario.Dt_Nascimento, usuario.Cep);

                if (query.Valid)
                {
                    result.Result = result.Object = _service.Insert(query);

                    if (!result.Result)
                    {
                        ((Notifiable)_service).Notifications
                            .ToList()
                            .ForEach(x => result.Messages.Add(x.Message));
                    }
                }
                else
                {
                    query.Notifications.ToList().ForEach(x => result.Messages.Add(x.Message));
                }
            }
            catch (Exception ex)
            {
                result.Messages.Add("Problemas ao inserir o Usuario " + ex.Message);
            }

            return result;
        }

        public ServiceResponse<List<UsuarioDto>> List()
        {
            var result = new ServiceResponse<List<UsuarioDto>>();

            try
            {
                var usuarios = _service.List();

                if (usuarios.Any())
                {
                    result.Object = new List<UsuarioDto>();

                    usuarios.ForEach(x => result.Object.Add(new UsuarioDto()
                    {
                        IdUsuario = x.IdUsuario,
                        Nome = x.Nome,
                        Cep = x.Cep
                    }));
                    result.Result = true;
                }
            }
            catch (Exception ex)
            {
                result.Messages.Add("Problemas ao lista os usuarios " + ex.Message);
            }

            return result;
        }

        public ServiceResponse<List<UsuarioDto>> Pesquisa(string str)
        {
            var result = new ServiceResponse<List<UsuarioDto>>();

            try
            {
                if (string.IsNullOrEmpty(str) || str.Length < 4)
                {
                    result.Messages.Add("Por favor insira pelo menos 3 caracteres ");
                }
                else
                {
                    var usuarios = _service.Pesquisa(str);
                    if (usuarios.Any())
                    {
                        result.Object = new List<UsuarioDto>();
                        usuarios.ForEach(x => result.Object.Add(new UsuarioDto()
                        {
                            IdUsuario = x.IdUsuario,
                            Nome = x.Nome,
                            Cep = x.Cep
                        }));
                        result.Result = true;
                    }
                    else
                    {
                        result.Messages.Add("Problemas ao listar o usuario");
                    }
                }
            }
            catch (Exception ex)
            {
                result.Messages.Add("Problems when try to search restaurants: " + ex.Message);
            }
            return result;
        }

        public ServiceResponse<bool> Update(UsuarioDto usuario)
        {
            var result = new ServiceResponse<bool>();

            try
            {
                var entity = _service.Get(usuario.IdUsuario);
                if (entity != null)
                {
                    entity.Modify(usuario.Nome, usuario.Dt_Nascimento, usuario.Cep);
                    if (entity.Valid)
                    {
                        result.Result = result.Object = _service.Update(entity);
                        if (!result.Result)
                        {
                            ((Notifiable)_service).Notifications
                                .ToList()
                                .ForEach(x => result.Messages.Add(x.Message));
                        }
                    }
                    else
                    {
                        entity.Notifications.ToList().ForEach(x => result.Messages.Add(x.Message));
                    }
                }
                else
                {
                    result.Messages.Add("Não foi possivel idenficar o Usuario");
                }
            }
            catch (Exception ex)
            {
                result.Messages.Add("Problema para alterar o usuario : " + ex.Message);
            }

            return result;
        }

        public ServiceResponse<bool> Exists(string NomeUsuario, string Senha)
        {
            var result = new ServiceResponse<bool>();

            try
            {

            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }
    }
}
