import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';

import { Cargo } from '../shares/cargo';
import { CargoService } from '../services/cargo.service';

@Component({
  selector: 'app-cargo-form',
  templateUrl: './cargo-form.component.html',
  styleUrls: ['./cargo-form.component.css']
})
export class CargoFormComponent implements OnInit {

  nivelCargo: NivelCargo[] = [];
  Cargo: Cargo = new Cargo();

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private CargoService: CargoService
  ) { }

  ngOnInit() {    
    var id = this.route.snapshot.params['id'];

    if (!id) 
      return;
    
    this.CargoService.getCargo(id)
      .subscribe(
      Cargo => this.Cargo = Cargo,
      response => {
        if (response.status == 404) {
          this.router.navigate(['cargo']);
        }
      });
  }

  save(form) {
    let result;
    let CargoValue = this.Cargo;
    if (CargoValue.Id) {
      result = this.CargoService.updateCargo(CargoValue);
    } else {
      result = this.CargoService.addCargo(CargoValue);
    }

    result.subscribe(data => this.router.navigate(['cargo']));
  }

  cancel() {
    this.router.navigate(['cargo']);
  }
}
