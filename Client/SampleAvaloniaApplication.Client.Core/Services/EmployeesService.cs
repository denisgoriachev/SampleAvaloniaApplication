using AutoMapper;
using DynamicData;
using SampleAvaloniaApplication.Client.Core.Data;
using SampleAvaloniaApplication.Client.Core.Models;
using SampleAvaloniaApplication.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleAvaloniaApplication.Client.Core.Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly IMapper _mapper;
        private readonly IDbContextFactory<SampleAvaloniaApplicationClientContext> _contextFactory;

        private readonly SourceCache<EmployeeModel, Guid> _employees;

        public IObservable<IChangeSet<EmployeeModel, Guid>> Connect() => _employees.Connect();

        public EmployeesService(IDbContextFactory<SampleAvaloniaApplicationClientContext> contextFactory, IMapper mapper)
        {
            _mapper = mapper;
            _contextFactory = contextFactory;

            _employees = new SourceCache<EmployeeModel, Guid>(e => e.Id);

            using (var context = _contextFactory.Create())
            {
                _employees.AddOrUpdate(_mapper.ProjectTo<EmployeeModel>(context.Employees));
            }
        }

        public Task<ServiceResult<EmployeeModel>> AddAsync(EmployeeModel model)
        {
            return Task.Run(() =>
            {
                using (var context = _contextFactory.Create())
                {
                    var entity = new ClientEmployee();
                    _mapper.Map(model, entity);

                    context.Employees.Add(entity);
                    context.SaveChanges();

                    _mapper.Map(entity, model);

                    _employees.AddOrUpdate(model);

                    return ServiceResult.Ok(model);
                }
            });
        }

        public Task<ServiceResult<EmployeeModel>> UpdateAsync(EmployeeModel model)
        {
            return Task.Run(() =>
            {
                using (var context = _contextFactory.Create())
                {
                    var entity = context.Employees.First(e => e.Id == model.Id);
                    _mapper.Map(model, entity);

                    context.SaveChanges();

                    _mapper.Map(entity, model);

                    _employees.AddOrUpdate(model);

                    return ServiceResult.Ok(model);
                }
            });
        }

        public Task DeleteAsync(EmployeeModel model)
        {
            throw new NotImplementedException("It is impossible to delete Employee");
        }

        public bool UsernameIsFree(string username)
        {
            using (var context = _contextFactory.Create())
            {
                return !context.Employees.Any(e => e.Username == username);
            }
        }
    }
}
