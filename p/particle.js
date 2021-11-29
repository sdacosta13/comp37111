import * as THREE from "https://web.cs.manchester.ac.uk/three/three.js-master/build/three.module.js";
import "/comp37111/p/constants.js"
export class Particle{
  constructor(pos, velocity){
    this.pos = pos;           // THREE.Vector3
    this.velocity = velocity; // THREE.Vector3
    this.sphereGeometry = new THREE.SphereGeometry(1,32,16);
    this.sphereMaterial = new THREE.MeshBasicMaterial({color: 0xFF0000});
    this.mesh = new THREE.Mesh(this.sphereGeometry, this.sphereMaterial);
    this.mesh.position.copy(this.pos);
  }
  setRandomVelocity(){
    var magnitude = randomint(100,200);              //random magnitude
    var angle1 = randomint(60, 90) * Math.PI / 180;
    var angle2 = randomint(0,359) * Math.PI / 180;
    var x = magnitude * Math.cos(angle1);
    var y = magnitude * Math.sin(angle1);
    var tempVec = new THREE.Vector3(x,y,0);
    this.velocity = tempVec.applyAxisAngle(new THREE.Vector3(0,1,0), angle2); // rotate 2D vector
    if(DEBUG){
      var dotgeo = new THREE.SphereGeometry(1,32,16);
      var dotmesh = new THREE.Mesh(dotgeo, this.sphereMaterial);
      dotmesh.position.copy(this.velocity);
      scene.add(dotmesh);
    }
  }
  update(time){
    var angle_xy = Math.tanh(this.velocity.y / this.velocity.x);
    var angle_zy = Math.tanh(this.velocity.y / this.velocity.z);
    var x = this.velocity.x * time * Math.cos(angle_xy);
    var z = this.velocity.z * time * Math.cos(angle_zy);
    var angle_y = Math.tanh(this.velocity.y / Math.sqrt((this.velocity.x ** 2) + (this.velocity.z ** 2)));
    var y = this.velocity.y * time * Math.sin(angle_y) - (0.5) * (GRAVITY * GRAVITY_MULTIPLIER) * time * time;
    this.mesh.position.setX(x);
    this.mesh.position.setY(y);
    this.mesh.position.setZ(z);
  }
}
