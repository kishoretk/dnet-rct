import { Box, Container, CssBaseline } from "@mui/material";
import NavBar from "./NavBar";
import TaskItemDashboard from "../../features/taskitems/dashboard/TaskItemDashboard";
import axios from "axios";
import { useEffect, useState } from "react";

function App() {
  const [taskItems, setTaskItems] = useState<TaskItem[]>([]);
  const [selectedTaskItem, setSelectedTaskItem] = useState<TaskItem | null | undefined>(null);
  const [editMode, setEditMode] = useState(false);

  const handleTaskItemSelect = (id: string) => {
    const taskItem = taskItems.find((item) => item.id === id);
    setSelectedTaskItem(taskItem || null);
  };

  const handleTaskItemCancel = () => setSelectedTaskItem(null);

  const handleOpenForm = (id?: string) => {
    if (id) handleTaskItemSelect(id);
    else handleTaskItemCancel();

    setEditMode(true);
  }

  const handleCloseForm = () => {
    setEditMode(false);
  }

  useEffect(() => {
    axios
      .get<TaskItem[]>("https://localhost:7023/api/taskitems")
      .then((response) => setTaskItems(response.data));
  }, []);

  return (
    <Box sx={{ bgcolor: "#f5f5f5", minHeight: "100vh" }}>
      <CssBaseline />
      <NavBar openForm={handleOpenForm} />

      <Container maxWidth="xl" sx={{ mt: 4 }}>
        <TaskItemDashboard
          taskitems={taskItems}
          selectedTaskItem={selectedTaskItem}
          selectTaskItem={handleTaskItemSelect}
          cancelTaskItem={handleTaskItemCancel}
          editMode={editMode}
          openForm={handleOpenForm}
          closeForm={handleCloseForm}
        />
      </Container>
    </Box>
  );
}

export default App;
