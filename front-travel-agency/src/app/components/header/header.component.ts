import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.sass']
})
export class HeaderComponent {
  destination: any;
  category: any;
  country: any;
  filterAll: any;
  target: string;

  constructor(private http: HttpClient) {
    this.target = "https://127.0.0.1:7094";
  }

  ngOnInit(): void {
    /*
    this.http.request<any>(this.target+"/api/Destination/all"+"/api/Country/all"+"/api/Category/all")
    .subscribe(resp => {
      this.destination = resp;
      this.category = resp;
      this.country = resp;
      this.filterAll = resp;
    });

    filterAll(destinationCity: string, countryTitle: string, categoryName: string) {
      this.filterAll = this.destination.filter((filter: any) => {
        return filter.destinationCity || filter.countryTitle || filter.categoryName;
      })
    }
    */
  }
}
