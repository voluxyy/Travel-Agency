import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-category-page',
  templateUrl: './category-page.component.html',
  styleUrls: ['./category-page.component.sass']
})
export class CategoryPageComponent {
  id: string;

  constructor(private http: HttpClient, private route: ActivatedRoute) {
    this.id = this.route.snapshot.params['id'];
  }
}
