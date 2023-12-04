import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import { Funcionario } from '../shares/Funcionario';
import { map } from 'rxjs/operators';

@Injectable()
export class FuncionarioService {
  url: string = "https://localhost:7169/api/funcionario";
  constructor(private http: HttpClient) {}

  getFuncionarios() {
    return this.http.get(this.url)
                    .pipe(map((res: Funcionario[]) => res));
  }

  getFuncionario(id) {
    return this.http.get(`${this.url}/${id}`).pipe(map((res: Funcionario) => res));
  }

  reviver(key, value) {
    if (value === "timestamp") {
      return new Date(value);
    }
    return value;
  }

  addFuncionario(funcionario: Funcionario) {
    return this.http.post(this.url, funcionario).pipe(map((res => res)));
  }

  addCargo(cargo) {
    return this.http.post(`${this.url}/cargo`, cargo).pipe(map((res) => res));
  }

  updateFuncionario(funcionario) {
    return this.http
      .put(this.getFuncionarioUrl(funcionario.Id), funcionario)
      .pipe(map((res) => res));
  }

  deleteFuncionario(id) {
    return this.http.delete(this.url + "/" + id).pipe(map((res) => res));
  }

  private getFuncionarioUrl(id) {
    return this.url + "/" + id;
  }
}
