<script>
import axios from 'axios'
const URL = "https://backend-to-to-service.azurewebsites.net/api/Tarea/"
    export default {
        name: 'MiTarea',
        data(){
            return{
                tarea: '',
                tareas: [],
                loading: false
            }
        },
        methods: {
            agregarTarea(){
                const tarea = {
                    name: this.tarea,
                    state: false
                }
                this.loading = true;
                axios.post(URL, tarea).then(response => {
                        console.log(response);
                        this.loading = false;
                        this.obtenerTareas();
                    }).catch(error => {
                        console.log(error);
                        this.loading = false;
                    })
                this.tarea = '';
            },
            eliminarTarea(id){
                this.loading = true;
                axios.delete(URL + id).then(response => {
                    console.log(response);
                    this.loading = false;
                    this.obtenerTareas();
                }).catch(error => {console.log(error);});
            },
            editarTarea(tarea, id)
            {
                this.loading = true;
                axios.put(URL + id, tarea).then(response => {
                    console.log(response);
                    this.obtenerTareas();
                    this.loading = false;
                }).catch(error => {
                    console.log(error)
                    this.loading = false
                }) 
            },
            obtenerTareas()
            {
                this.loading = true;
                axios.get(URL).then(response => {
                   console.log(response);
                   this.loading = false;
                   this.tareas = response.data;
                }).catch(() => this.loading = false);
            },


        },
        created: function()
        {
            this.obtenerTareas();
        }
    }
</script>

<template>
    <div>
        <h1 class="display-4 text-center">Listado de tareas</h1>
        <hr>
        <div class="row">
            <div class="col-lg-8 offset-lg-2">
                <div class="card mt-4">
                    <div class="card-body">
                        <div class="input-group">
                            <input type="text" v-model="tarea" class="form-control form-control-lg" placeholder="Agregar Tarea">
                                <div class="input-group-append">
                                    <button v-on:click="agregarTarea()" 
                                        class="btn btn-success btn-lg">Agregar</button>
                                </div>
                        </div>
                        <br>
                        <div class="text-center">
                            <div v-if="loading" class="spinner-border text-success" role="status">
                            <span class="visually-hidden">Loading...</span>
                        </div>
                        </div>
                        <h5 v-if="(tareas.length == 0)">No hay tareas para realizar</h5>
                        <ul v-if="!loading" class="list-group">
                            <li v-for="(tarea, index) of tareas" :key="index"
                             class="list-group-item d-flex justify-content-between">
                                <span class="cursor" v-bind:class="{'text-success' : tarea.state}" v-on:click="editarTarea(tarea, tarea.id)">
                                    <i v-bind:class="[tarea.state ? 'fa-solid fa-circle-check' : 'fa-regular fa-circle']"></i>
                                </span>
                                {{ tarea.name }}
                                <span class="text-danger cursor" v-on:click="eliminarTarea(tarea.id)">
                                    <i class="fa-solid fa-trash"></i>
                                </span>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<style scoped>
.cursor{
    cursor: pointer;
}
</style>

