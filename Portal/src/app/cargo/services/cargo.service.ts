import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions } from '@angular/http';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';

@Injectable()
export class CargoService {

  url: string = "https://localhost:7169/api/Cargo";
  constructor(private http: Http) { }

  getCargos() {
    return this.http.get(this.url)
      .map(res => res.json());
  }

  getCargo(id) {
    return this.http.get(this.getCargoUrl(id))
      .map(res => JSON.parse(res.text(), this.reviver));
  }

  reviver(key, value) {
    if (value === "timestamp") {
      return new Date(value);
    }
    return value;
  }

  addCargo(Cargo) {
    let body = JSON.stringify(Cargo);
    let headers = new Headers({ 'Content-Type': 'application/json' });
    let options = new RequestOptions({ headers: headers });
    return this.http.post(this.url, body, options)
      .map(res => res.json());
  }

  updateCargo(Cargo) {
    let body = JSON.stringify(Cargo);
    let headers = new Headers({ 'Content-Type': 'application/json' });
    let options = new RequestOptions({ headers: headers });
    return this.http.put(this.getCargoUrl(Cargo.Id), body, options)
      .map(res => res.json());
  }

  deleteCargo(id) {
    console.log(id);
    return this.http.delete(this.getCargoUrl(id))
      .map(res => res.json());
  }

  private getCargoUrl(id) {
    return this.url + "/" + id;
  }
}
