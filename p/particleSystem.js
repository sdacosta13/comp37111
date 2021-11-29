import * as THREE from "https://web.cs.manchester.ac.uk/three/three.js-master/build/three.module.js";
import { OrbitControls } from "https://web.cs.manchester.ac.uk/three/three.js-master/examples/jsm/controls/OrbitControls.js";
import {Particle} from "/comp37111/p/particle.js"
import "/comp37111/p/constants.js"
var p;
var scene, camera, renderer, controls
function init(){
  scene = new THREE.Scene();
  camera = new THREE.PerspectiveCamera(75, window.innerWidth / window.innerHeight, 0.1, 10000);
  camera.position.set(0, 0, 400);
  camera.lookAt(0,0,0);
  renderer = new THREE.WebGLRenderer();
  renderer.setClearColor(0x000000, 1.0);
  renderer.setSize(window.innerWidth, window.innerHeight);
  document.body.appendChild(renderer.domElement);
  var controls = new OrbitControls(camera, renderer.domElement);
  controls.autoRotate = true;
  var geometry = new THREE.PlaneGeometry(100,100);
  var material = new THREE.MeshBasicMaterial({color: 0x325ca8});
  var mesh = new THREE.Mesh(geometry, material);
  mesh.rotateOnAxis(new THREE.Vector3(1,0,0), -0.5 * Math.PI);
  var axes = new THREE.AxesHelper(30);
  scene.add(axes);
  scene.add(mesh);
  initParticles();
}
function initParticles(){
  p = new Particle(new THREE.Vector3(0,0,0), new THREE.Vector3(5,5,5));
}
function animate(){
  requestAnimationFrame(animate);
  update();
  renderer.render(scene, camera);
}
function update(){
  clock += dt;
  p.update();
}
try{
  init();
  animate();
} catch (err) {
  alert(err.message);
}
