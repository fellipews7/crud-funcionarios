import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';

import { FuncionarioService } from '../services/funcionario.service';
import { Funcionario } from './../shares/Funcionario';

@Component({
  selector: 'app-funcionario-detail',
  templateUrl: './funcionario-detail.component.html',
  styleUrls: ['./funcionario-detail.component.css']
})
export class FuncionarioDetailComponent implements OnInit {

  funcionario: Funcionario;

  constructor(
    private router: Router,
    private funcionarioService: FuncionarioService
  ) { }

  ngOnInit() {
  }

  novo() {
    this.router.navigate(['funcionario/novo/recursofuncionario/novo']);
  }

}
