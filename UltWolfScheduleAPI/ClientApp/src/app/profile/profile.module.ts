import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common'; 
import { OrdinaryTasksComponent } from './ordinary-tasks/ordinary-tasks.component';
import { ProfileComponent } from './profile/profile.component';
import { MainProfileComponent } from './main-profile/main-profile.component';
import { FormsModule } from '@angular/forms';
import { DlDateTimePickerDateModule } from 'angular-bootstrap-datetimepicker';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    DlDateTimePickerDateModule ],
  declarations: [  OrdinaryTasksComponent, ProfileComponent, MainProfileComponent]
})
export class ProfileModule { }
