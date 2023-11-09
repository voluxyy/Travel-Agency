import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.sass']
})
export class HomeComponent implements OnInit {
  destinations: any;
  target: string;

  constructor(private http: HttpClient) {
    this.target = "https://127.0.0.1:7094";
  }

  ngOnInit(): void {
    this.http.get<any>(this.target+"/api/Destination/all")
    .subscribe(resp => this.destinations = resp);
  }
}
