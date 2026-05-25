import { Box, Button, Paper, TextField } from "@mui/material"

type Props = {
    closeForm: () => void
    taskitem?: TaskItem
}

export const TaskItemForm = ({ closeForm, taskitem }: Props) => {
    return (
        <Paper sx={{ padding: 2, borderRadius: 2, boxShadow: "0 2px 5px rgba(0, 0, 0, 0.4)" }}>
            <h2>{taskitem ? "Edit" : "Create"} Task</h2>
            <Box component="form" sx={{ display: "flex", flexDirection: "column", gap: 2 }}>
                <TextField id="title" label="Title" variant="outlined" fullWidth value={taskitem?.title} />
                <TextField id="description" label="Description" variant="outlined" value={taskitem?.description} fullWidth multiline rows={4} />
                <TextField id="dateAdded" label="Date Added" variant="outlined" value={taskitem ? new Date(taskitem.dateAdded).toLocaleDateString() : ""} fullWidth disabled />
                <TextField id="isCompleted" label="Status" variant="outlined" value={taskitem?.iscompleted ? "Completed" : "Pending"} fullWidth />
                <Box sx={{ display: "flex", justifyContent: "flex-end", gap: 2 }}>
                    <Button color="inherit" variant="outlined" onClick={closeForm}>
                        Cancel
                    </Button>
                    <Button color="success" variant="contained">
                        Submit
                    </Button>
                </Box>
            </Box>
        </Paper>
    )
}
