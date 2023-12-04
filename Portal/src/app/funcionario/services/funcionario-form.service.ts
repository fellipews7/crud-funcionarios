import { Injectable, EventEmitter } from '@angular/core';
import { Funcionario } from '../shares/Funcionario';

@Injectable()
export class FuncionarioFormService {

  novoFuncionario = new EventEmitter<Funcionario>();

  constructor() { }

  novoRecusoFuncionario(funcionario: Funcionario) {
    this.novoFuncionario.emit(funcionario);
  }

}
