import { DashboardComponent } from './dashboard/dashboard.component';
import { DepartmentComponent } from './departments/departments.component';
import { TasksComponent } from './tasks/tasks.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeesComponent } from './employees/employees.component';

const routes: Routes = [
	{ path: '', component: DashboardComponent },
	{ path: 'tasks', component: TasksComponent },
	{ path: 'employees', component: EmployeesComponent },
	{ path: 'departments', component: DepartmentComponent }
];

@NgModule({
	imports: [ RouterModule.forRoot(routes) ],
	exports: [ RouterModule ]
})
export class AppRoutingModule {}
