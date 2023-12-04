import { Injectable, EventEmitter } from '@angular/core';
import { Cargo } from '../shares/cargo';

@Injectable()
export class CargoFormService {

  emitirNovoCargo = new EventEmitter<Cargo>();

  constructor() { }

  novoCargo(cargo: Cargo){
    this.emitirNovoCargo.emit(cargo);
  }
}
