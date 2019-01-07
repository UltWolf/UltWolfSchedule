import { Component, OnInit } from '@angular/core';

import { OrdinaryTask } from '../../Models/OrdinaryTask';

@Component({
  selector: 'app-ordinary-tasks',
  templateUrl: './ordinary-tasks.component.html',
  styleUrls: ['./ordinary-tasks.component.css']
})
export class OrdinaryTasksComponent implements OnInit {

  Task:OrdinaryTask = new OrdinaryTask();
  Tasks: OrdinaryTask  [];
  incrementid: number = 0;
  incrementdoneid: number=0;
  constructor() {
    this.Tasks = [];
  }
  showTask() {
    var doc = document.getElementsByClassName("create_task");
    doc[0].className = "create_task_modal";
  }
  addTask(x) {
    if (this.Tasks.length == 0) {
      this.Tasks = [{ Name:x.Name, Description: x.title, DateTime: x.description,isActive :true }];
    } else {
      this.incrementid = this.incrementid["id"] + 1;
      this.Tasks.push({ Name:x.Name, Description: x.title, DateTime: x.description,isActive :true });
    }
    var doc = document.getElementsByClassName("create_task_modal");
    doc[0].className = "create_task";
}
  ngOnInit() {
  }

}
