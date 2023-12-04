import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';

import { CargoService } from '../services/cargo.service';
import { Cargo } from '../shares/cargo';

@Component({
  selector: 'app-cargo-detail',
  templateUrl: './cargo-detail.component.html',
  styleUrls: ['./cargo-detail.component.css']
})
export class CargoDetailComponent implements OnInit {
  
  cargo: Cargo;

  constructor(
    private router: Router,
    private CargoService: CargoService
  ) { }

  ngOnInit() {
  }

  novo() {
    this.router.navigate(['cargo/novo']);
  }

  delete(cargo: Cargo){
    console.log(1);
    console.log(cargo);
    
    this.CargoService.deleteCargo(cargo.Id)
  }

}
