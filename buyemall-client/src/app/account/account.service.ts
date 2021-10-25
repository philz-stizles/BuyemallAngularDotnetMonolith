import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = 'https://localhost:44374/api'

  constructor(private http: HttpClient) { }

  register(userCredentials: any) {
    this.http.post(`${this.baseUrl}/Account/Register`, userCredentials)
  }

  Login(userCredentials: any) {
    this.http.post(`${this.baseUrl}/Account/Register`, userCredentials)
  }
}
