import { Injectable, Inject } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
 
import { HttpClient } from '@angular/common/http';
import { User } from '../Models/User';


@Injectable()
export class AuthenticationService {
  constructor(private http: HttpClient) { }
  
}
