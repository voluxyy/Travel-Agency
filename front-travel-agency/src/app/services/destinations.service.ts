import { Injectable } from '@angular/core';
import { Destinations } from '../models/destination';

@Injectable({
  providedIn: 'root'
})
export class DestinationsService {

  constructor() { }

  public getDestination() : Destinations[] {
    let dest = new Destinations();
    dest.id = 1;
    dest.countryId = 1;
    dest.categoryId = 1;
    dest.city = "Paris";
    dest.capital = true;
    dest.toDo = [];

    return [dest];
  }
}
