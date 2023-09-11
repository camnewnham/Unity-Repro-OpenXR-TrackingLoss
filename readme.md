This repo reproduces an issue where session tracking does not recover when moving to a new space on HoloLens 2


# Reproduction Steps
- Pull/create project (see below for from-scratch instructions)
- On HoloLens, "Remove All Holograms" to clear tracking data
- Build and deploy
- Observe normal behaviour at launch - spatial meshes visible, SessionTracking
- Cover HoloLens sensors to cause tracking loss
- With sensors covered, move to another room
- Uncover sensors
- Observe that tracking does not recover. Spatial meshes not visible, SessionInitializing

- Return to main space and allow device to relocalize
- Observe that session tracking recovers and meshes reappear

![image](https://github.com/camnewnham/Unity-Repro-OpenXR-TrackingLoss/assets/19278856/cd1b6096-fd3c-4428-828c-2c197bdd9a05)

## From Scratch
- Create new Unity project in 2022.3.9f1
- Add XR packages
 - XR Plugin Management 4.3.3
 - OpenXR Plugin 1.8.2
 - Mixed Reality OpenXR Plugin 1.8.1 (via scoped registry)
- Enable OpenXR + Microsoft HoloLens feature group in XR Plugin Management
- Add XR Origin, Tracked Pose Driver
- Add an ARMeshManager with visuals (i.e. VR/SpatialMesh shader)
- Accept fixes (permissions) for OpenXR project validation
