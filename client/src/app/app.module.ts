import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule, HTTP_INTERCEPTORS} from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RegisterComponent } from './register/register.component';
import { TextInputComponent } from './_forms/text-input/text-input.component';
import { DateInputComponent } from './_forms/date-input/date-input.component';
import { SharedModule } from './_modules/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HomeComponent } from './home/home.component';
import { NavComponent } from './nav/nav.component';
import { GigAddComponent } from './modals/gig-add/gig-add.component';
import { GigEditComponent } from './modals/gig-edit/gig-edit.component';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { GigDetailComponent } from './gigs/gig-detail/gig-detail.component';
import { GigListComponent } from './gigs/gig-list/gig-list.component';
import { ContactComponent } from './contact/contact.component';
import { DisclaimerComponent } from './disclaimer/disclaimer.component';
import { ErrorInterceptor } from './_interceptors/error.interceptor';
import { JwtInterceptor } from './_interceptors/jwt.interceptor';
import { DatePipe, DecimalPipe } from '@angular/common';
import { HasRoleDirective } from './_directives/has-role.directive';
import { UserEditComponent } from './user/user-edit/user-edit.component';
import { PhotoEditorComponent } from './photo-editor/photo-editor.component';
import { UserDetailComponent } from './user/user-detail/user-detail.component';
import { UserCardComponent } from './user/user-card/user-card.component';

@NgModule({
  declarations: [
    AppComponent,
    RegisterComponent,
    TextInputComponent,
    DateInputComponent,
    HomeComponent,
    NavComponent,
    GigAddComponent,
    GigEditComponent,
    NotFoundComponent,
    ServerErrorComponent,
    GigDetailComponent,
    GigListComponent,
    ContactComponent,
    DisclaimerComponent,
    HasRoleDirective,
    UserEditComponent,
    PhotoEditorComponent,
    UserDetailComponent,
    UserCardComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    SharedModule
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true},
    {provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true},
    DatePipe, DecimalPipe
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
