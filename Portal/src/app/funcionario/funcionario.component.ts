import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';

import { Funcionario } from './shares/Funcionario';
import { FuncionarioService } from './services/funcionario.service';

@Component({
  selector: 'app-funcionario',
  templateUrl: './funcionario.component.html',
  styleUrls: ['./funcionario.component.css']
})
export class FuncionarioComponent implements OnInit {

  funcionarios: Funcionario[] = []

  constructor(
    private router: Router,
    private funcionarioService: FuncionarioService
  ) { }

  ngOnInit() {
    this.funcionarioService.getFuncionarios().subscribe({
      next: (response) => (this.funcionarios = response),
      error: (error) => console.log(error)
    });
  }

  novo() {
    this.router.navigate(['funcionario/novo']);
  }

  delete(funcionario) {
    if (confirm("Tem certeza de que deseja excluir " + funcionario.Data + " - " + funcionario.ResponsavelNome + "?")) {
      var index = this.funcionarios.indexOf(funcionario);
      this.funcionarios.splice(index, 1);

      let result = this.funcionarioService.deleteFuncionario(funcionario.id);
      result.subscribe(data => this.router.navigate(['funcionario']),
        err => {
          alert("Não foi possível excluir a Funcionario.");
          this.funcionarios.splice(index, 0, funcionario);
        });
    }
  }

}
