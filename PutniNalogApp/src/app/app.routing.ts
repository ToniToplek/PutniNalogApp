import { Routes, RouterModule } from '@angular/router';

import { PutniNalogComponent } from './putni-nalog/putni-nalog.component';
import { AdminComponent } from './admin';

const routes: Routes = [
    { path: '', component: PutniNalogComponent },
    { path: 'admin', component: AdminComponent },


    // otherwise redirect to home
    { path: '**', redirectTo: '' }
];

export const appRoutingModule = RouterModule.forRoot(routes);