import { DashboardComponent } from './dashboard/dashboard.component';
import { DepartmentComponent } from './departments/departments.component';
import { BrowserModule } from '@angular/platform-browser';
import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpClientModule }    from '@angular/common/http';
import { AppComponent } from './app.component';
import { TasksComponent } from './tasks/tasks.component';
import { EmployeesComponent } from './employees/employees.component';
import { TaskComponent } from './task/task.component';
import { AppRoutingModule } from './app-routing.module';


@NgModule({
	declarations: [
		AppComponent,
		TasksComponent,
		DepartmentComponent,
		EmployeesComponent,
		TaskComponent,
		DashboardComponent,
	],
	imports: [ BrowserModule, FormsModule, AppRoutingModule, NgbModule, HttpClientModule ],
	providers: [],
	bootstrap: [ AppComponent ],
	schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class AppModule {}
