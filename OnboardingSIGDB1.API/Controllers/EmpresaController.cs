using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnboardingSIGDB1.Data;
using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Entities;
using OnboardingSIGDB1.Domain.Interfaces.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnboardingSIGDB1.API.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {
        private readonly IEmpresaService _empresaService;
        
        private readonly DataContext _context;
        
        public EmpController(DataContext context, IEmpresaService empresaServices)
        {
            _context = context;
            _empresaService = empresaServices;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<EmpresaDto>>> Get()
        {
            var empresas = await _context.Empresa.ToListAsync();
            var empresasDto = new List<EmpresaDto>();
            foreach (var empresa in empresas)
            {
                var empresaDto = new EmpresaDto()
                {
                    Id = empresa.Id,
                    Cnpj = empresa.Cnpj,
                    Nome = empresa.Nome,
                    DataFundacao = empresa.DataFundacao
                };
                empresasDto.Add(empresaDto);
            }
            
            return empresasDto;
        }

        [HttpPost]
        public async Task<ActionResult<EmpresaDto>> Post([FromBody] EmpresaDto empresaDto)
        {
            var empresa = new Empresa(empresaDto.Nome,empresaDto.Cnpj,empresaDto.DataFundacao);
            _context.Empresa.Add(empresa);
            await _context.SaveChangesAsync();
            empresaDto.Id = empresa.Id;
            return empresaDto;
        }

        [HttpDelete("{empId}")]
        public async Task Delete(int empId)
        {
            await _empresaService.Deletar(empId);
        }
    }
}
