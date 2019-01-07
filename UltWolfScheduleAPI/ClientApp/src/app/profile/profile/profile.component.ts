import { UserProfile } from './../../Models/UserProfile';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  User:UserProfile = new UserProfile();
  constructor() { }

  ngOnInit() {
  }

}
