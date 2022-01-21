import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import  { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';

const routes: Routes = [
  { path:'' , redirectTo:'home',pathMatch:'full'},
  { path: 'show', loadChildren: () => import('./feature/show/show.module').then(m => m.ShowModule) },
  { path: 'about', loadChildren: () => import('./feature/about/about.module').then(m => m.AboutModule) },
  { path: 'addstudent', loadChildren: () => import('./feature/addstudent/addstudent.module').then(m => m.AddstudentModule) },
  { path: 'home', loadChildren: () => import('./home/home.module').then(m => m.HomeModule) },
  { path: 'login', component: LoginComponent},
  { path: '**', component:HomeComponent }
 
   ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
