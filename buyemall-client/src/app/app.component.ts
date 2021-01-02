import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { IProduct } from './shared/models/product'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit{
  title = 'buyemall-client';
  products: IProduct[]

  constructor(private http: HttpClient){}

  ngOnInit(): void {
    this.http.get('')
      .subscribe((response: any) => {
        console.log(response)
        this.products = response
      })
  }
}
