import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContactComponent } from './contact/contact.component';
import { DisclaimerComponent } from './disclaimer/disclaimer.component';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { GigDetailComponent } from './gigs/gig-detail/gig-detail.component';
import { GigListComponent } from './gigs/gig-list/gig-list.component';
import { HomeComponent } from './home/home.component';
import { MessagesComponent } from './messages/messages.component';
import { GigEditComponent } from './modals/gig-edit/gig-edit.component';
import { UserDetailComponent } from './user/user-detail/user-detail.component';
import { UserEditComponent } from './user/user-edit/user-edit.component';
import { AuthGuard } from './_guards/auth.guard';
import { PreventUnsavedChangesGuard } from './_guards/prevent-unsaved-changes.guard';
import { GigResolverResolver } from './_resolvers/gig-resolver.resolver';
import { MemberDetailedResolver } from './_resolvers/member-detailed.resolver';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      {path: 'gigs', component: GigListComponent},
      {path: 'members/:username', component: UserDetailComponent, resolve: {member:MemberDetailedResolver}},
      {path: 'gigs/:id', component: GigDetailComponent, resolve: {gig: GigResolverResolver}},
      {path: 'gig/edit', component: GigEditComponent, canDeactivate: [PreventUnsavedChangesGuard]},
      {path: 'messages', component: MessagesComponent},
      {path: 'user/edit', component: UserEditComponent, canDeactivate: [PreventUnsavedChangesGuard]},
    ]
  },
  {path: 'contact', component: ContactComponent},
  {path: 'disclaimer', component: DisclaimerComponent},
  {path: 'not-found', component: NotFoundComponent},
  {path: 'server-error', component: ServerErrorComponent},
  {path: '**', component: NotFoundComponent, pathMatch:'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
