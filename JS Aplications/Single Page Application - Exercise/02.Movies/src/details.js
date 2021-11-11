
import { showView } from './dom.js';

let section = document.getElementById(`movie-details`);
section.remove();

export function showDetails(){

    showView(section);
}