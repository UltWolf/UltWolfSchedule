import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../../Services/AuthenticationService.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit { 
  username: string;
  password: string;
  constructor(private   service: AuthenticationService) { }

  ngOnInit() {
  }
  Login() {
    this.service.Authorization(this.username, this.password).subscribe(result => {
    if (result.ok === true) {
        console.log(result);
      } else {
       
      }
    }, err => {
      console.log(err); 
    });
  }

}
