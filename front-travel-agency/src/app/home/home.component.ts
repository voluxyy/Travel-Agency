import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ViewChild, ElementRef } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.sass']
})
export class HomeComponent implements OnInit {
  destinations: any;
  filteredDestinations: any;

  category: any;

  getCountryName: any;

  target: string;

  constructor(private http: HttpClient) {
    this.target = "https://127.0.0.1:7094";
  }

  ngOnInit(): void {
    this.http.get<any>(this.target+"/api/Destination/all")
    .subscribe(resp => {
      this.destinations = resp;
      this.filteredDestinations = resp;
    });

    this.http.get<any>(this.target+"/api/Category/all")
    .subscribe(resp => this.category = resp);
    
    this.http.get<any>(this.target+"/api/Country/get/"+ this.destinations)
    .subscribe(resp => this.getCountryName = resp)
  }

  filterDestinations(categoryTitle: string) {
    this.filteredDestinations = this.destinations.filter((dest: any) => {
      return dest.category === categoryTitle;
    });
  }

  @ViewChild('.filters-list') sidebarElement!: ElementRef;
  isGrabbed: boolean = false;
  initialX: number = 0;
  offsetX: number = 0;

  moveSidebar(){
    const minoffset= 0;
    const maxoffset= 200;

    if (this.offsetX > minoffset && this.offsetX < maxoffset) {
      if (this.sidebarElement) {
        this.sidebarElement.nativeElement.style.transform = `translateX(${this.offsetX}px)`;
      }
    }
  }

  onMouseDown(event: MouseEvent) {
    this.isGrabbed = true;
    this.initialX = event.clientX - this.offsetX;
  }

  onMouseUp(event: MouseEvent) {
    this.isGrabbed = false;
  }

  onMouseMove(event: MouseEvent) {
    if (this.isGrabbed) {
      event.preventDefault();
      this.offsetX = event.clientX - this.initialX;
      this.moveSidebar();
    }
  }
}
