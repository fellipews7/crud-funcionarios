import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';

import * as moment from 'moment'
import { Funcionario } from './../shares/Funcionario';
import { FuncionarioService } from '../services/funcionario.service';
import { CargoService } from '../../cargo/services/cargo.service';
import { Cargo } from '../../cargo/shares/cargo';
import { FuncionarioCargo } from '../shares/FuncionarioCargo';

@Component({
  selector: 'app-funcionario-form',
  templateUrl: './funcionario-form.component.html',
  styleUrls: ['./funcionario-form.component.css']
})
export class FuncionarioFormComponent implements OnInit {

  funcionario: Funcionario = new Funcionario();
  cargos: Cargo[]
  funcionarioCargo: FuncionarioCargo = new FuncionarioCargo();
  responsavel: any = {};

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private funcionarioService: FuncionarioService,
    private cargoService: CargoService
  ) { }

  ngOnInit() {    
    var id = this.route.snapshot.params['id'];  

    this.cargoService.getCargos().subscribe({
        next: (response) => (this.cargos = response),
        error: (error) => console.log(error),
      });

    if (!id) 
      return;
    
    this.funcionarioService.getFuncionario(id)
      .subscribe(
      funcionario => this.funcionario = funcionario,
      response => {
        if (response.status == 404) {
          this.router.navigate(['']);
        }
      });
  }

  save(form) {
    let result;
    let funcionarioValue = this.funcionario;
    funcionarioValue.Ativo = true;
    if (funcionarioValue.Id) {
      result = this.funcionarioService.updateFuncionario(funcionarioValue);
    } else {
      result = this.funcionarioService.addFuncionario(funcionarioValue);
    }

    result.subscribe({
      next: (data) =>{
        this.funcionarioCargo.FuncionarioId = data.id;
        this.funcionarioService.addCargo(this.funcionarioCargo).subscribe({
          next: data => console.log(data),
        });
        this.router.navigate(["funcionario"]);
      } ,
    });
  }

  cancel() {
    this.router.navigate(['funcionario']);
  }

  abrirModal(){

  }
}
