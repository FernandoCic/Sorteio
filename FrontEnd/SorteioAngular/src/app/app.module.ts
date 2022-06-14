import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ParticipanteSorteadosComponent } from './participante-sorteados/participante-sorteados.component';
import { ParticipanteComponent } from './participante/participante.component';
import { ParticipantesService } from './service/participante.service';
import {MatTabsModule} from '@angular/material/tabs';
import {MatListModule} from '@angular/material/list';
import { MenuComponent } from './menu/menu.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { LayoutModule } from '@angular/cdk/layout';
import { MatMenuModule } from '@angular/material/menu';
import { MatButtonModule} from '@angular/material/button'; 
import { MatDatepickerModule} from '@angular/material/datepicker';
import { MatNativeDateModule} from '@angular/material/core'; 
import { MatIconModule} from '@angular/material/icon'; 
import { MatCardModule} from '@angular/material/card'; 
import { MatRadioModule} from '@angular/material/radio'; 
import { MatSidenavModule} from '@angular/material/sidenav'; 
import { MatFormFieldModule} from '@angular/material/form-field'; 
import { MatInputModule} from '@angular/material/input'; 
import { MatTooltipModule} from '@angular/material/tooltip'; 
import { MatToolbarModule} from '@angular/material/toolbar'; 
import { MatTableModule} from '@angular/material/table'; 


@NgModule({
  declarations: [
    AppComponent,
    ParticipanteComponent,
    ParticipanteSorteadosComponent,
    MenuComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatTabsModule,
    MatListModule,
    BrowserModule,
    FormsModule, 
    ReactiveFormsModule,  
    HttpClientModule,
    BrowserAnimationsModule,
    MatButtonModule,  
    MatMenuModule,  
    MatDatepickerModule,  
    MatNativeDateModule,  
    MatIconModule,  
    MatRadioModule,  
    MatCardModule,  
    MatSidenavModule,  
    MatFormFieldModule,  
    MatInputModule,  
    MatTooltipModule,  
    MatToolbarModule,  
    AppRoutingModule, LayoutModule, MatListModule  ,
    RouterModule,
    MatTableModule
    
  ],
  providers: [ParticipantesService],
  bootstrap: [AppComponent]
})
export class AppModule { }
