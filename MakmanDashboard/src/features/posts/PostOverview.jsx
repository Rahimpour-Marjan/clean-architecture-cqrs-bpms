import { useNavigate } from 'react-router-dom';
import styled from 'styled-components';
import { useDeletePost } from '../../hooks/useDeletePost';
import { ConfirmationModal } from './ConfirmationModal';
import { PostActions } from './PostActions';
import { PostDetails } from './PostDetails';
import { PostImage } from './PostImage';
import React from 'react';

const PostContainer = styled.div`
  display: flex;
  width: 35rem;
  border-radius: var(--border-radius-2);
  background-color: var(--white);
  box-shadow: var(--shadow-1);
`;

export const PostOverview = ({ post }) => {
  const navigate = useNavigate();
  const { deleteUserPost, isDeleting } = useDeletePost();

  const [visible, setVisible] = React.useState(false);

  const {
    id: postId,
    image: postImage,
    title: name,
    description,
    category,
  } = post;

  const closeModal = () => {
    setVisible(false);
  };

  return (
    <PostContainer>
      <PostImage postImage={postImage} />
      <PostDetails name={name} description={description} category={category} />
      <PostActions
        onEdit={() => {
          navigate(`edit/${postId}`);
        }}
        onDelete={() => {
          setVisible(true);
        }}
      />
      {visible && (
        <ConfirmationModal
          disabled={isDeleting}
          onConfirm={() =>
            deleteUserPost(postId, {
              onSuccess: closeModal,
            })
          }
          onCloseModal={closeModal}
        />
      )}
    </PostContainer>
  );
};
