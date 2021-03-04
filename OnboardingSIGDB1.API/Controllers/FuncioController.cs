using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnboardingSIGDB1.Data;
using OnboardingSIGDB1.Domain.Dto;
using OnboardingSIGDB1.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnboardingSIGDB1.API.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class FunController : ControllerBase
    {
        private readonly DataContext _context;
        public FunController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<FuncionarioDto>>> Get()
        {
            var funcionarios = await _context.Funcionario.ToListAsync();
            var funcionariosDto = new List<FuncionarioDto>();
            foreach (var funcionario in funcionarios)
            {
                var funcionarioDto = new FuncionarioDto()
                {
                    Id = funcionario.Id,
                    Cpf = funcionario.Cpf,
                    Nome = funcionario.Nome,
                    DataContratacao = funcionario.DataContratacao
                };
                funcionariosDto.Add(funcionarioDto);
            }

            return funcionariosDto;
        }
        
        [HttpPost]

        public async Task<ActionResult<FuncionarioDto>> Post([FromBody] FuncionarioDto funcionarioDto)
        {
            var funcionario = new Funcionario(funcionarioDto.Nome, funcionarioDto.Cpf, funcionarioDto.DataContratacao);
            _context.Funcionario.Add(funcionario);
            await _context.SaveChangesAsync();
            funcionarioDto.Id = funcionario.Id;
            return funcionarioDto;
        }



        


    }
}
