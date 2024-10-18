using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProjectileLine: MonoBehaviour
{
	static private Slingshot S;
	[Header( "Set in Inspector" )]
	public float minDist = 0.1f;
	private LineRenderer line;
	private GameObject _poi;
	private List<Vector3> points;
	private Rigidbody projectileRigidbody;

	static public Vector3 LAUNCH_POS {
	get {
	if (S == null) return Vector3.zero;
	return S.launchPos;
	}
	}
	void Awake() {
	S = this;// Set the singleton
	// Get a reference to the LineRenderer
	line = GetComponent<LineRenderer>();
	line.enabled = false;
	points = new List<Vector3>();
	}
	public GameObject poi {
	get {
	return ( _poi );
	}
	set {
	_poi =value ;
	if ( _poi !=null ) {
	line.enabled = false;
	points = new List<Vector3>();
	AddPoint();
	}
	}
	}
	public void Clear() {
	_poi =null;
	line.enabled = false;
	points = new List<Vector3>();
	}
	public void AddPoint() {

	Vector3 pt = _poi.transform.position;
	if ( points.Count > 0 && (pt - lastPoint).magnitude < minDist ) {
	return;
	}
	if ( points.Count == 0 ) { // If this is the launch point...
	Vector3 launchPosDiff = pt -Slingshot.LAUNCH_POS; // To be defined
	points.Add( pt + launchPosDiff );
	points.Add(pt);
	line.positionCount = 2;
	line.SetPosition(0, points[0] );
	line.SetPosition(1, points[1] );
	line.enabled = true;
	} else {
	points.Add( pt );
	line.positionCount = points.Count;
	line.SetPosition( points.Count-1, lastPoint );
	line.enabled = true;
	}
	}
	public Vector3 lastPoint {
	get {
	if (points == null ) {
	return ( Vector3.zero );
	}
	return ( points[points.Count-1] );
	}
	}
	void FixedUpdate () {
	if ( poi == null ) {
	if (FollowCam.POI != null ) {
	if (FollowCam.POI.tag == "Projectile" ) {
	poi = FollowCam.POI;
	}else {
	return; // Return if we didn't find a poi
	}
	} else {
	return; // Return if we didn't find a poi
	}
	}
	AddPoint();
	if (FollowCam.POI == null ) {
	poi = null;
	}
	}
	}


    
