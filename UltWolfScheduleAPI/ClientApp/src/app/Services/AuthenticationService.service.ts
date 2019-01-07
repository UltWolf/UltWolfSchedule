import { Injectable, Inject } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Rx';
import { BehaviorSubject } from 'rxjs/Rx';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { User } from '../Models/User';


@Injectable()
export class AuthenticationService {
  constructor(private http: HttpClient) { } 
  Registration(User: User) { 
    return this.http.post(  '/api/users/register',  User).map((response) => {
      return response;
    }).catch((error: any) => {
      return Observable.throw(error|| 'server error');
    });
  }
  Authorization(username: string, password: string) {
    var body = { username: username, password: password };
    return this.http.post('/api/users/authenticate', body).map((response) => { 
      return response;
    }).catch((error: any) => {
      return Observable.throw(error || 'server error');
    });;
  }
}
