import { Component} from '@angular/core';
import { Destinations } from 'src/app/models/destination';
import { DestinationsService } from 'src/app/services/destinations.service';

@Component({
  selector: 'app-database',
  templateUrl: './database.component.html',
  styleUrls: ['./database.component.sass']
})
export class DatabaseComponent {
  destinations: Destinations[] = [];

  constructor(private DestinationsService: DestinationsService) { }

  ngOnInit(): void {
    this.destinations = this.DestinationsService.getDestination();
    console.log(this.destinations);
  }

  /*
  updateDestination(category) {

  }

  createDestination(category) {
    
  }

  deleteDestination(category) {
    
  }
  */
}
