import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-destination-page',
  templateUrl: './destination-page.component.html',
  styleUrls: ['./destination-page.component.sass'],
})
export class DestinationPageComponent {
  id: string;

  constructor(private http: HttpClient, private route: ActivatedRoute) {
    this.id = this.route.snapshot.params['id'];
  }
}
