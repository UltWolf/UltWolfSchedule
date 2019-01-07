import { Component, OnInit } from '@angular/core';
import { User } from '../../Models/User';
import { AuthenticationService } from '../../Services/AuthenticationService.service';  
import { Router } from '@angular/router';
@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit { 
  user: any = {};
  constructor(
    private router: Router,private httpService:AuthenticationService) { }
  error = "";
  ngOnInit() {
  }
  Registration() {
    console.log("REGISTER");
    var userToDB = new User();
    userToDB.username = this.user.username;
    userToDB.password = this.user.password;
    userToDB.email = this.user.email; 
    this.httpService.Registration(userToDB ).subscribe(result => {
      if (result == null) {
        this.router.navigate(["/user/login"]);
      } else  if (result.ok === true) {
        console.log(result);
      }   else {
        this.error = 'Username or password is incorrect';

        console.log(result);
      }
    }, err => {
      console.log(err);
      this.error = 'Username or password is incorrect';
    });
  }
}
