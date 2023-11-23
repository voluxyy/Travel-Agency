import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.sass']
})
export class UserComponent implements OnInit {
  user:any;
  target: string;

  constructor(private http: HttpClient) {
    this.target = "https://127.0.0.1:7094"
  }

  ngOnInit(): void{
    this.http.get<any>(this.target+"/api/User")
    .subscribe(resp => this.user = resp);
  }

}
