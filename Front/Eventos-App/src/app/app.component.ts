import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { PalestrantesComponent } from "./palestrantes/palestrantes.component";
import { EventosComponent } from "./eventos/eventos.component";

@Component({
    selector: 'app-root',
    standalone: true,
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.scss'],
    imports: [CommonModule, RouterOutlet, PalestrantesComponent, EventosComponent]
})
export class AppComponent {
  title = 'Eventos-App';
}
