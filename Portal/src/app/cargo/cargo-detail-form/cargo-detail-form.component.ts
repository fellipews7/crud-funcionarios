import { Component, OnInit } from '@angular/core';

import { CargoFormService } from '../services/cargo-form.service';
import { Cargo } from '../shares/cargo';

@Component({
  selector: 'app-cargo-detail-form',
  templateUrl: './cargo-detail-form.component.html',
  styleUrls: ['./cargo-detail-form.component.css']
})
export class CargoDetailFormComponent implements OnInit {

  cargo: Cargo = new Cargo();

  constructor(
    private CargoFormService: CargoFormService
  ) { }

  ngOnInit() {
  }

  save(f) {
    this.CargoFormService.novoCargo(this.cargo);
  }

}
