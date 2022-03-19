import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core'
import { Router } from '@angular/router'
import { ReplaySubject } from 'rxjs'
import { map } from 'rxjs/operators'
import { environment } from 'src/environments/environment'
import { IUser } from './../shared/models/user'

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  baseUrl = environment.baseUrl
  private currentUserSource = new ReplaySubject<IUser>(1)
  currentUser$ = this.currentUserSource.asObservable()

  constructor(private http: HttpClient, private router: Router) {}

  register(userCredentials: any) {
    return this.http
      .post(`${this.baseUrl}/account/register`, userCredentials)
      .pipe(
        map((user: IUser) => {
          if (user) {
            localStorage.setItem('token', user.token)
            this.currentUserSource.next(user)
          }
        })
      )
  }

  login(userCredentials: any) {
    return this.http
      .post(`${this.baseUrl}/account/login`, userCredentials)
      .pipe(
        map((user: IUser) => {
          if (user) {
            localStorage.setItem('token', user.token)
            this.currentUserSource.next(user)
          }
        })
      )
  }

  logout() {
    localStorage.removeItem('token')
    this.currentUserSource.next(null)
    this.router.navigateByUrl('/')
  }

  checkEmailExists(email: string) {
    return this.http.get(`${this.baseUrl}/account/email-exists?email=${email}`)
  }
}
