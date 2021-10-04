class Particle{
  constructor(pos, velocity){
    this.pos = pos;           // THREE.Vector3
    this.velocity = velocity; // THREE.Vector3
    this.sphereGeometry = new THREE.SphereColours(1,32,16);
    this.sphereMaterial = new THREE.MeshBasicMaterial({color: new THREE.Color(0xFF0000});
    this.mesh = new THREE.Mesh(this.sphereGeometry, this.sphereMaterial);
    this.mesh.position = this.pos;
  }
}
