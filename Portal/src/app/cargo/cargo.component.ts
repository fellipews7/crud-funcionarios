import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';

import { Cargo } from './shares/cargo';
import { CargoService } from './services/cargo.service';

@Component({
  selector: 'app-cargo',
  templateUrl: './cargo.component.html',
  styleUrls: ['./cargo.component.css']
})
export class CargoComponent implements OnInit {

  Cargos: Cargo[] = []

  constructor(
    private router: Router,
    private CargoService: CargoService
  ) { }

  ngOnInit() {
    this.CargoService.getCargos()
    .subscribe(data => {        
      this.Cargos = data
      console.log(this.Cargos)
    });
  }

  novo() {
    this.router.navigate(['cargo/novo']);
  }

  delete(Cargo) {
    console.log(Cargo)
    if (confirm("Tem certeza de que deseja excluir " + Cargo.id + " - " + Cargo.nome + "?")) {
      var index = this.Cargos.indexOf(Cargo);
      this.Cargos.splice(index, 1);

      let result = this.CargoService.deleteCargo(Cargo.id);
      result.subscribe(),
        err => {
          alert("Não foi possível excluir a Cargo.");
          this.Cargos.splice(index, 0, Cargo);
        };
    }
  }

}
